using AutoMapper;
using DAL_Core.Entities;
using TreatmentBL.Models;

namespace TreatmentBL.Profiles;
public class TreatmentMappingProfile : Profile
{
    public TreatmentMappingProfile()
    {
        CreateMap<HealthCare, TreatmentDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TreatmentName))
            .ForMember(dest => dest.IsExpired, opt => opt.MapFrom(src => src.ExpirationDate <= DateTime.Now))
            .ReverseMap();
    }
}
