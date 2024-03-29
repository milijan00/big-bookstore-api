﻿using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Books.Queries
{
    public interface IGetBookByIdQuery : IQuery<BookDto>
    {
        public Guid Id { get; set; }
    }
}
