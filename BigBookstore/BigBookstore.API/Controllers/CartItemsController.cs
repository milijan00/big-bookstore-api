using BigBookstore.Implementation.BusinessLogic.Cartitems.Commands;
using BigBookstore.Implementation.BusinessLogic.Cartitems.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : BigBookstoreBaseController
    {
        public CartItemsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetByCart(Guid cartId) => Ok(await this.Mediator.Send(new GetCartItemsByCartQuery() { CartId = cartId}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCartItemCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpDelete] 
        public async Task<IActionResult> Delete(Guid cartId, Guid bookId)
        {
            await this.Mediator.Send(new DeleteCartItemCommand() { CartId = cartId, BookId = bookId });
            return NoContent();
        }
    }
}
