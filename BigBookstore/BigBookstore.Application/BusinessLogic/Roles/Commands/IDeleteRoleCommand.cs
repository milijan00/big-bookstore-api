﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Roles.Commands
{
    public interface IDeleteRoleCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
    }
}
