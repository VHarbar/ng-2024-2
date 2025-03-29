using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Service.Interface;
public interface ITreatmentService
{
    Task<List<TreatmentDto>> GetAllTreatments();
}
