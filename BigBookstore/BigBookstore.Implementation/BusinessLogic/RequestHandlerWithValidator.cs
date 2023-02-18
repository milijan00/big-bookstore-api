using BigBookstore.Application.BusinessLogic;
using BigBookstore.Application.Services;
using BigBookstore.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBookstore.Implementation.Exceptions;

namespace BigBookstore.Implementation.BusinessLogic
{
    public abstract class RequestHandlerWithValidator<TUseCase, TResponse, TValidator> : RequestHandler<TUseCase, TResponse>
        where TUseCase : IUseCase<TResponse>
        where TValidator : BaseValidator<TUseCase>
    {
        protected TValidator Validator { get; }

        protected RequestHandlerWithValidator(IApplicationService service, TValidator validator) : base(service)
        {
            this.Validator = validator;
        }
        public override async  Task<TResponse> Handle(TUseCase request, CancellationToken cancellationToken)
        {
            var result = this.Validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }
            return await this.ExecuteOperation(request);
        }
        protected abstract Task<TResponse> ExecuteOperation(TUseCase request);
    }
}
