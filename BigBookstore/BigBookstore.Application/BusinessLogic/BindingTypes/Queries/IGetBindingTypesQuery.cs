﻿using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.BindingTypes.Queries
{
    public interface IGetBindingTypesQuery : IQuery<IEnumerable<BindingTypeDto>>
    {
    }
}
