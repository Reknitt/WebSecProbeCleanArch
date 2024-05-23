using MediatR;
using Presentation.Domain.Entities.UserEntities;

namespace WebSecProbeCleanArch.Application.Queries.UserQueries
{
    public class UserQueryByLoginAndPassword : IRequest<User?>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
