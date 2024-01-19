using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.DataContext;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon.S3;
using Amazon.Runtime;
using Core.Domain.Constants;

namespace Core.Extension.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services, Type startupType, Profile profile)
        {
            try
            {
                services.AddAutoMapper(startupType);
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(profile);
                });
                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when add auto mapper with error: {ex}");
            }
            return services;
        }

        public static IServiceCollection AddDbContextConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<CoreDbContext>()
           .AddDefaultTokenProviders();

            services.AddIdentityCore<User>();
            services.AddDbContext<CoreDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.CoreDbConnectionString));
            });
            return services;
        }

        public static IServiceCollection AddBasicConfigure(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(p => p.AddDefaultPolicy(build =>
            {
                build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddHealthChecks();
            return services;
        }

        public static IServiceCollection AddAWSConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var awsSetting = configuration.GetSection(ConfigurationKeys.AWS);
            var awsOption = configuration.GetAWSOptions();
            var credential = new BasicAWSCredentials(awsSetting[ConfigurationKeys.AccessKey], awsSetting[ConfigurationKeys.SecretKey]);
            awsOption.Credentials = credential;
            awsOption.Region = Amazon.RegionEndpoint.USEast1;
            services.AddDefaultAWSOptions(awsOption);
            services.AddAWSService<IAmazonS3>();
            return services;
        }

    }
}
