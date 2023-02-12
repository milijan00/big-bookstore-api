using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Exceptions
{
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public List<ValidationFailure> Errors { get; }
    }
}
