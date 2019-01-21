using System;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using FluentValidation;
using WebApiServerConsole.Services;

namespace WebApiServerConsole.Middleware
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private readonly ILoggerService _loggerService;

        public GlobalExceptionHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;
            var code = GetStatusCode(exception);

            if (code == HttpStatusCode.InternalServerError)
                _loggerService.Error(exception.Message);
            else
                _loggerService.Warning(exception.Message);

            context.Result = new ResponseMessageResult(context.Request.CreateResponse(code, context.Exception.Message));
        }

        private static HttpStatusCode GetStatusCode(Exception ex)
        {
            switch (ex)
            {
                case UnauthorizedAccessException _: return HttpStatusCode.Unauthorized;
                case ValidationException _: return HttpStatusCode.BadRequest;
                case InstanceNotFoundException _: return HttpStatusCode.NotFound;
                case InvalidOperationException _: return HttpStatusCode.Forbidden;
                default: return HttpStatusCode.InternalServerError;
            }
        }
    }
}