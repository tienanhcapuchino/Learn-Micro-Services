using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

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
                throw ex;
            }
            return services;
        }

        public static IServiceCollection AddDbContextConfigure(this IServiceCollection services)
        {
            return services;
        }

    }
}
