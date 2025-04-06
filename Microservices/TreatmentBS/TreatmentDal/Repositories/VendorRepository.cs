using DAL_Core;
using DAL_Core.Entities;
using TreatmentDal.Repositories.Interfaces;

namespace TreatmentDal.Repositories;
public class VendorRepository : Repository<Vendor>, IVendorRepository
{
    public VendorRepository(PetStoreDbContext ctx) : base(ctx)
    {
    }
}
