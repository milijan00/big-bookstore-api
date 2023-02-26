using BigBookstore.Implementation.BusinessLogic.Carts.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BigBookstoreBaseController
    {
        public CartsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCartCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateCartCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteCartCommand() { Id = id });
            return NoContent();
        }
    }
}
