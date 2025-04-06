using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace SentinelBusinessLayer.Service;
public class TreatmentService : ITreatmentService
{
    private readonly ITreatmentClient _treatmentClient;

    public TreatmentService(ITreatmentClient treatmentClient)
    {
        _treatmentClient = treatmentClient;
    }

    public async Task<List<TreatmentDto>> GetAllTreatments()
    {
        return await _treatmentClient.GetAllTreatments();
    }
}
