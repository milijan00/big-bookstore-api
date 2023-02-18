using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public  abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator(BigBookStoreDbContext context)
        {
            Context = context;
        }
        protected BigBookStoreDbContext Context { get; }
    }
}
