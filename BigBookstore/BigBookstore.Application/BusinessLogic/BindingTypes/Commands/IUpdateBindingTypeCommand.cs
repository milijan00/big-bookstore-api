﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.BindingTypes.Commands
{
    public interface IUpdateBindingTypeCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
