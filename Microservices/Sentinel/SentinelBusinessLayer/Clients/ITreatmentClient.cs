using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients;
public interface ITreatmentClient
{
    [Get("/api/treatment")]
    Task<List<TreatmentDto>> GetAllTreatments();
}
