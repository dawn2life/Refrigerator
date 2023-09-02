using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Refrigerator.Api.Data.DataAccess;
using Refrigerator.Api.Data.Infrastructure;
using Refrigerator.Api.Domain.Configurations;

namespace Refrigerator.Api.Data
{
    public static class Register
    {
        public static void ConfigureDataLayer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConnection, Connection>();
            var connectionString = configuration.GetSection(nameof(ConnectionStrings)).GetRequiredSection("RefrigeratorDb:ConnectionString").Value;
            services.AddDbContext<RefrigeratorContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.RegisterAssemblyPublicNonGenericClasses()
                .Where(cls => cls.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces();
        }
    }
}
