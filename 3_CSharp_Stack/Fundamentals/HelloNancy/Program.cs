using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace HelloNancy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder() //An object that allows us to connect to a server and perform HTTP requests.
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
