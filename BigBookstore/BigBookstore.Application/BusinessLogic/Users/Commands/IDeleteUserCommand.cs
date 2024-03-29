﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Users.Commands
{
    public interface IDeleteUserCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
    }
}
