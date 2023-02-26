using BigBookstore.Implementation.BusinessLogic.Letters.Commands;
using BigBookstore.Implementation.BusinessLogic.Letters.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LettersController : BigBookstoreBaseController
    {
        public LettersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetLettersQuery()));
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetLetterByIdQuery() { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLetterCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateLetterCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteLetterCommand() { Id = id });
            return NoContent();
        }
    }
}
