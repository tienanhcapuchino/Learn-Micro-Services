using Core.Domain.DataContext;
using Core.Domain.Entities;
using Core.Extension.Application;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBasicConfigure();
            services.AddOcelot(new ConfigurationBuilder()
                .AddJsonFile("ocelot.json")
                .Build());
            services.AddDbContextConfigure(Configuration);
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseBasicConfigure(env);

            app.UseOcelot();
            
        }
    }
}
