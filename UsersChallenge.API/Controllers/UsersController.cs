using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersChallenge.Application;
using UsersChallenge.Domain.Exceptions;
using UsersChallenge.Domain.Ports;

namespace UsersApiChallenge.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var user = await _mediator.Send(new FindUserRequest(id));
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> Post([FromBody] CreateUserRequest request)
        {
            try
            {
                var user = await _mediator.Send(request);
                return Ok($"User created with id '{user.Id}'");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateUserState")]
        public async Task<ActionResult> Put(Guid id, [FromBody] bool Active)
        {
            try
            {
                await _mediator.Send(new UpdateUserStateRequest(id, Active));
                return Ok($"User {id} updated.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteUserRequest(id));
                return Ok($"User {id} deleted.");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}