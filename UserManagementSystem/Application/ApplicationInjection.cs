using Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationInjection
    {
        public static void AddApplication(
           this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperBLLProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
