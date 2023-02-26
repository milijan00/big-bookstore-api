using BigBookstore.Implementation.BusinessLogic.Users.Commands;
using BigBookstore.Implementation.BusinessLogic.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BigBookstoreBaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetUsersQuery()));

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetUserByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateUserCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteUserCommand() { Id = id });
            return NoContent();
        }
    }
}
