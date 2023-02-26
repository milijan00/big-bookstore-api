using BigBookstore.Implementation.BusinessLogic.Roles.Commands;
using BigBookstore.Implementation.BusinessLogic.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BigBookstoreBaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetRolesQuery()));
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetRoleByIdQuery() { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateRoleCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteRoleCommand() { Id = id });
            return NoContent();
        }
    }
}
