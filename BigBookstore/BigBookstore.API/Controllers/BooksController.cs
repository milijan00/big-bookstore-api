using BigBookstore.Implementation.BusinessLogic.Books.Commands;
using BigBookstore.Implementation.BusinessLogic.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BigBookstoreBaseController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetBooksQuery()));
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetBookByIdQuery() { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateBookCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteBookCommand() { Id = id });
            return NoContent();
        }
    }
}
