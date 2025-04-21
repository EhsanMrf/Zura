using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zura.Application.Common.UnitOfWork;
using Zura.Infrastructure.Persistence.UnitOfWork;

namespace Zura.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

            return services;
        }
    }
}
