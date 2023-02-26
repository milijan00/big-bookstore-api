using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BigBookstoreBaseController : ControllerBase
    {
        protected IMediator Mediator { get; }
        public BigBookstoreBaseController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}
