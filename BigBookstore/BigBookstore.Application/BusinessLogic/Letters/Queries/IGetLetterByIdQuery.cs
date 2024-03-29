﻿using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Letters.Queries
{
    public interface IGetLetterByIdQuery : IQuery<LetterDto>
    {
        public Guid Id { get; set; }
    }
}
