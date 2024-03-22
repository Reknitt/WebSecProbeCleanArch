using MediatR;

namespace WebSecProbeCleanArch.Application.Commands.UserCommands.Create
{
    public class CreateUserCommand : IRequest<int>
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
