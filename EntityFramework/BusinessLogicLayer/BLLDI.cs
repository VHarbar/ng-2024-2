using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Services.Classes;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class BLLDI
    {
        public static void AddBLLLayer(
           this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperBLLProfile));
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
