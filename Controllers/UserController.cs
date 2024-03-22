using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Domain.Entities.UserEntities;
using WebSecProbeCleanArch.Application.Commands.UserCommands.Create;
using WebSecProbeCleanArch.Application.Queries.UserQueries;

namespace WebSecProbeCleanArch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand createUser, CancellationToken token)
        {
            int userId = await _mediator.Send(createUser, token);
            return Ok(userId);
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] UserQueryById userQueryById, CancellationToken token)
        {
            User user = await _mediator.Send(userQueryById, token);
            return Ok(user);
        }
    }
}
