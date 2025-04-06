using Application.Users.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class AutomapperBLLProfile : Profile
    {
        public AutomapperBLLProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
