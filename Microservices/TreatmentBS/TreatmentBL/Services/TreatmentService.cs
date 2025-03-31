using AutoMapper;
using DAL_Core.Entities;
using TreatmentBL.Models;
using TreatmentBL.Services.Interfaces;
using TreatmentDal.Repositories.Interfaces;

namespace TreatmentBL.Services;
public class TreatmentService : ITreatmentService
{
    private readonly IHealthCareRepository _healthCareRepository;
    private readonly IMapper _mapper;

    public TreatmentService(IHealthCareRepository healthCareRepository, IMapper mapper)
    {
        _healthCareRepository = healthCareRepository;
        _mapper = mapper;
    }

    public async Task<bool> GetTreatmentStatus(Guid id)
    {
        var healthCare = await _healthCareRepository.GetHealthCareWithDetails(id);

        if (healthCare == null)
        {
            throw new Exception($"TE: Treatment with ID={id} not found");
        }

        var treatment = _mapper.Map<TreatmentDto>(healthCare);

        return treatment.IsExpired;
    }

    public async Task<TreatmentDto> GetTreatment(Guid id)
    {
        var healthCare = await _healthCareRepository.GetHealthCareWithDetails(id);

        if (healthCare == null)
        {
            throw new Exception($"TE: Treatment with ID={id} not found");
        }

        return _mapper.Map<TreatmentDto>(healthCare);
    }

    public async Task<List<TreatmentDto>> GetAllTreatments()
    {
        var healthCare = await _healthCareRepository.GetAllAsync();

        return _mapper.Map<List<TreatmentDto>>(healthCare);
    }

    public async Task<Guid> AddNewTreatment(TreatmentDto treatment)
    {
        var healthCare = _mapper.Map<HealthCare>(treatment);

        await _healthCareRepository.CreateAsync(healthCare);

        return healthCare.Id;
    }
}
