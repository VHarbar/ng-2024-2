using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Queries
{
    public record GetUserByIdQuery(Guid userId) : IRequest<UserDto>;

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
