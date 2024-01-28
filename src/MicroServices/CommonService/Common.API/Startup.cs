using Common.API.AutoMapper;
using Common.Service.Interfaces;
using Common.Service.Services;
using Common.Service.Services.DataUpgrade;
using Core.Domain.Constants;
using Core.Extension.Application;
using Core.Service.Interfaces;

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
            services.AddBasicConfigure();
            services.AddDbContextConfigure(Configuration);
            services.AddAWSConfig(Configuration);
            services.AddAutoMapperConfig(typeof(Startup), new MappingProfile());

            #region register services
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

            #region data upgrade services
            services.AddScoped<IDataUpgradeService, RoleDataUpgradeService>();
            #endregion

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseBasicConfigure(env, MicroServiceComponent.Common);
        }
    }
}
