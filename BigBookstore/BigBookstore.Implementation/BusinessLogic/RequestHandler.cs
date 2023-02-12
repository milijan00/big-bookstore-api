using BigBookstore.Application.BusinessLogic;
using BigBookstore.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic
{
    public abstract class RequestHandler<TUseCase, TResponse> : IUseCaseHandler<TUseCase, TResponse>
        where TUseCase : IUseCase<TResponse>
    {
        private readonly IApplicationService _service;
        protected IApplicationService ApplicationService => this._service;
        public RequestHandler(IApplicationService service)
        {
            this._service = service;
        }

        public abstract Task<TResponse> Handle(TUseCase request, CancellationToken cancellationToken);
    }
}
