using System;

namespace WebApiServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var apiService = new ApiService(9000);

            apiService.Start();
            Console.Out.WriteLine("Api Server has started");
            Console.ReadLine();

            apiService.Stop();
        }
    }
}
