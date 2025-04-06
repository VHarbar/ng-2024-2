using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreatmentDal.Repositories;
using TreatmentDal.Repositories.Interfaces;

namespace TreatmentDal;
public static class TreatmentDalInjection
{
    public static void AddTreatmentDalLogic(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PetStoreDbContext>(options =>

                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IHealthCareRepository, HealthCareRepository>();
        services.AddScoped<IVendorRepository, VendorRepository>();
    }
}
