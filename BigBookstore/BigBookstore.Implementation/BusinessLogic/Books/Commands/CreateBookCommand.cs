﻿using BigBookstore.Application.BusinessLogic.Books.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.Books.Commands
{
    public class CreateBookCommand : ICreateBookCommand
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LetterId { get; set; }
        public Guid BindingTypeId { get; set; }
        public uint Pages { get; set; }
        public string Image { get; set; }
    }

    public class CreateBookCommandHandler : RequestHandlerWithValidator<CreateBookCommand, Unit, CreateBookValidator>
    {
        public CreateBookCommandHandler(IApplicationService service, CreateBookValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(CreateBookCommand request)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                AuthorId = request.AuthorId,
                LetterId = request.LetterId,
                CategoryId = request.CategoryId,
                BindingTypeId = request.BindingTypeId,
                Image = request.Image,
                Pages = request.Pages
            };

            await this.ApplicationService.CreateAsync<Book>(book);

            return new Unit();
        }
    }

}
