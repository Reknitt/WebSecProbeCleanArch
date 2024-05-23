using MediatR;
using Presentation.Domain.Entities.UserEntities;
using Presentation.Domain.Interfaces;

namespace WebSecProbeCleanArch.Application.Queries.UserQueries
{
    public class UserQueryByLoginAndPasswordHandler(IUserRepository userRepository) : IRequestHandler<UserQueryByLoginAndPassword, User?>
    {
        public Task<User?> Handle(UserQueryByLoginAndPassword request, CancellationToken cancellationToken)
        {
            return userRepository.GetByLoginAndPasswordAsync(request.Login, request.Password);
        }
    }
}
