using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("ocelot.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddOcelot(Configuration);
            services.AddReverseProxy()
                .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
            services.AddHealthChecks();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOcelot();
            app.MapReverseProxy();
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
                AllowCachingResponses = true,
            });
        }
    }
}
