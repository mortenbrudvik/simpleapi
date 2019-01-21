using System;

namespace WebApiServerConsole.Services
{
    public class LoggerService : ILoggerService
    {
        public void Info(string message)
        {
            Console.Out.WriteLine($"Info: {message}");
        }

        public void Debug(string message)
        {
            Console.Out.WriteLine($"Debug: {message}");
        }

        public void Warning(string message)
        {
            Console.Out.WriteLine($"Warning: {message}");
        }

        public void Error(string message)
        {
            Console.Out.WriteLine($"Error: {message}");
        }
    }
}