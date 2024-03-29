﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Letters.Commands
{
    public interface ICreateLetterCommand : ICommand<Unit>
    {
        public string Name { get; set; }
    }
}
