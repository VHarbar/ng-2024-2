using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Initializer;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessLayerInjection
    {
        public static void AddDataAccessLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WebShopDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<SeedDb>();
        }
    }
}
