using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Users.Queries
{
    public interface IGetUserByIdQuery : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
