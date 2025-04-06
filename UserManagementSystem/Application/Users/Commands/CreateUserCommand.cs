using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Commands
{
    public record CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userToAdd = new User(request.UserName);
            return await _userRepository.CreateAsync(userToAdd);
        }
    }
}
