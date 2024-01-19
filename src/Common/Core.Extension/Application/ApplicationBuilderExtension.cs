using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension.Application
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseBasicConfigure(this WebApplication app, IWebHostEnvironment env)
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
            app.UseCors(build =>
            {
                build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();
            app.UseRouting();

            app.UseAuthorization();
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
            return app;
        }
    }
}
