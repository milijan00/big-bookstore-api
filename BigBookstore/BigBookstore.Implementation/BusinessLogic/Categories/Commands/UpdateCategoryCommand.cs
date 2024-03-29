﻿using BigBookstore.Application.BusinessLogic.Categories.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Categories.Commands
{
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
    }
    public class UpdateCategoryCommandHandler : RequestHandlerWithValidator<UpdateCategoryCommand, Unit, UpdateCategoryValidator>
    {
        public UpdateCategoryCommandHandler(IApplicationService service, UpdateCategoryValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(UpdateCategoryCommand request)
        {
            var category = await this.ApplicationService.GetByIdAsync<Category>(request.Id);
            category.Name = request.Name;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
