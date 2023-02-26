using BigBookstore.Implementation.BusinessLogic.Authors.Commands;
using BigBookstore.Implementation.BusinessLogic.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BigBookstoreBaseController
    {
        public AuthorsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetAuthorsQuery()));
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetAuthorByIdQuery() { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateAuthorCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteAuthorCommand() { Id = id });
            return NoContent();
        }
    }
}
