using BigBookstore.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic
{
    public interface IUseCaseHandler<TUseCase, TResponse> : IRequestHandler<TUseCase, TResponse>
        where TUseCase: IUseCase<TResponse>
    {
    }
}
