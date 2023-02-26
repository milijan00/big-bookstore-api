using BigBookstore.Implementation.BusinessLogic.Categories.Commands;
using BigBookstore.Implementation.BusinessLogic.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BigBookstoreBaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this.Mediator.Send(new GetCategoriesQuery()));
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id) => Ok(await this.Mediator.Send(new GetCategoryByIdQuery() { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommand command)
        {
            await this.Mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateCategoryCommand command)
        {
            await this.Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeleteCategoryCommand() { Id = id });
            return NoContent();
        }
    }
}
