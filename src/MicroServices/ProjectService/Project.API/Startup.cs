using Core.Extension.Application;

namespace Project.API
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
            services.AddDbContextConfigure(Configuration);

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseBasicConfigure(env);
        }
    }
}
