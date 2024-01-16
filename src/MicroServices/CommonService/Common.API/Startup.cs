namespace Common.API
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
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
        }
    }
}
