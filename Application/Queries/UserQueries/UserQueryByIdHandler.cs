using MediatR;
using Presentation.Domain.Entities.UserEntities;
using Presentation.Domain.Interfaces;

namespace WebSecProbeCleanArch.Application.Queries.UserQueries
{
    public class UserQueryByIdHandler(IUserRepository userRepository) : IRequestHandler<UserQueryById, User>
    {
        public Task<User> Handle(UserQueryById request, CancellationToken cancellationToken)
        {
            return userRepository.GetByIdAsync(request.Id);
        }
    }
}
