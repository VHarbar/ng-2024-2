namespace SentinelAbstraction.Settings;
public class TreatmentClientSettings
{
    //Implement here a setting, which will containt config from RefitClients:T - where T is client section


    public const string SectionName = "TreatmentClient";

    public string BaseAddress { get; set; } = string.Empty;
}
