using TreatmentBL.Models;

namespace TreatmentBL.Services.Interfaces;
public interface ITreatmentService
{
    Task<bool> GetTreatmentStatus(Guid id);

    Task<TreatmentDto> GetTreatment(Guid id);

    Task<List<TreatmentDto>> GetAllTreatments();

    Task<Guid> AddNewTreatment(TreatmentDto treatment);
}
