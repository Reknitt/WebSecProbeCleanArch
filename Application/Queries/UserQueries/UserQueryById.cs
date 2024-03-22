using MediatR;
using Presentation.Domain.Entities.UserEntities;

namespace WebSecProbeCleanArch.Application.Queries.UserQueries
{
    public class UserQueryById : IRequest<User>
    {
        public required int Id { get; set; }
    }
}
