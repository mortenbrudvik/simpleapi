namespace WebApiServerConsole.Services
{
    public interface ILoggerService
    {
        void Info(string message);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
    }
}