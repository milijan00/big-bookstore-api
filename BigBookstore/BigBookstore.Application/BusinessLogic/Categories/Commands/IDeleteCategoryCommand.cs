﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Categories.Commands
{
    public interface IDeleteCategoryCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
    }
}
