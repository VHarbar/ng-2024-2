using DAL_Core.Entities;

namespace TreatmentDal.Repositories.Interfaces;
public interface IHealthCareRepository : IRepository<HealthCare>
{
    Task<HealthCare?> GetHealthCareWithDetails(Guid id);
}
