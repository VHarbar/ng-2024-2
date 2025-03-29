using Microsoft.Extensions.DependencyInjection;
using TreatmentBL.Profiles;
using TreatmentBL.Services;
using TreatmentBL.Services.Interfaces;

namespace TreatmentBL;
public static class TreatmentBlInjection
{
    public static void AddTreatmentBusinessLogic(
        this IServiceCollection services)
    {
        services.AddScoped<ITreatmentService, TreatmentService>();

        services.AddAutoMapper(typeof(TreatmentMappingProfile));
    }
}
