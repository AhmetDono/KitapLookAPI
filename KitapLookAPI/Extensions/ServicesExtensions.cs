using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contract;

namespace KitapLookAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );
        }

        public static void ConfigurationRepositoryManager(this IServiceCollection services) => 
            services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
