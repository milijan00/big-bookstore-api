﻿using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Authors.Queries
{
    public interface IGetAuthorsQuery : IQuery<IEnumerable<AuthorDto>>
    {
    }
}
