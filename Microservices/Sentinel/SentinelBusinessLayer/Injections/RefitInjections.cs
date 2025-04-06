using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Clients;

namespace SentinelBusinessLayer.Injections;
public static class RefitInjections
{
    //private static readonly TreatmentClientSettings _treatmentSettings;

    public static void AddRefitClients(
        this IServiceCollection services,
        IConfiguration configuration,
        IOptions<TreatmentClientSettings> treatmentOptions)
    {
        //_treatmentSettings = treatmentOptions.Value ?? throw new ArgumentNullException(nameof(treatmentOptions));


        services.AddRefitClient<ITreatmentClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7037")); 
            //use Options<T> to automatically assign configs to settings
    }
}
