using DAL_Core;
using DAL_Core.Entities;
using Microsoft.EntityFrameworkCore;
using TreatmentDal.Repositories.Interfaces;

namespace TreatmentDal.Repositories;
public class HealthCareRepository : Repository<HealthCare>, IHealthCareRepository
{
    private readonly PetStoreDbContext _context;

    public HealthCareRepository(PetStoreDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<HealthCare?> GetHealthCareWithDetails(Guid id)
    {
        var treatment = await _context.HealthCares
            .Include(x => x.Vendor)
            .Include(x => x.Pet)
            .FirstOrDefaultAsync(x => x.Id == id);

        return treatment;
    }
}
