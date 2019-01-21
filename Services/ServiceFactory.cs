namespace WebApiServerConsole.Services
{
    public class ServiceFactory
    {
        public ILoggerService CreateLogger()
        {
            return new LoggerService();
        }
    }
}