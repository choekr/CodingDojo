using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Nancy.Owin;
namespace HelloNancy
{
    public class Startup
    {
        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseOwin(x => x.UseNancy());
        }
    }
}