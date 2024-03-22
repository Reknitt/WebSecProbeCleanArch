using MediatR;
using Presentation.Domain.Entities.UserEntities;
using Presentation.Domain.Interfaces;

namespace WebSecProbeCleanArch.Application.Commands.UserCommands.Create
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
    {
        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Login = request.Login,
                Password = request.Password,
                Email = request.Email
            };

            return userRepository.CreateAsync(user);
        }
    }
}
