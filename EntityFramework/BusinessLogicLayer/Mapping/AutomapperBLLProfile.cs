using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public class AutomapperBLLProfile : Profile
    {
        public AutomapperBLLProfile()
        {
            CreateMap<Account, AccountModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<User, UserModel>();
        }
    }
}
