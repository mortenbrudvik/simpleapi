using System;
using Microsoft.Owin.Hosting;

namespace ConsoleApp4
{
    public class ApiService
    {
        private readonly string _baseAddress;
        private IDisposable _server;

        public ApiService(int port)
        {
            _baseAddress = $"http://+:{port}";
        }

        public void Start()
        {
            Console.Out.WriteLine($"Starting Api Server: {_baseAddress}");
            _server = WebApp.Start<StartUp>(_baseAddress);
        }

        public void Stop()
        {
            _server?.Dispose();
        }
    }
}