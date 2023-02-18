using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Categories.Queries
{
    public interface IGetCategoryByIdQuery : IQuery<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
