using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Refrigerator.Api.Services
{
    public static class Register
    {
        public static void ConfigureServiceLayer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.RegisterAssemblyPublicNonGenericClasses()
                    .Where(cls => cls.Name.EndsWith("Service"))
                    .AsPublicImplementedInterfaces();

            Refrigerator.Api.Data.Register.ConfigureDataLayer(services, configuration);
        }

        public static Type[] GetAutoMapperProfiles()
        {
            return typeof(Register).Assembly.GetTypes().Where(z => z.IsSubclassOf(typeof(Profile))).ToArray();
        }
    }
}
