using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace TimeDisplay
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
        }
        public void Configure(IApplicationBuilder App)
        {
            App.UseMvc();
            App.UseStaticFiles();
        }
    }
}