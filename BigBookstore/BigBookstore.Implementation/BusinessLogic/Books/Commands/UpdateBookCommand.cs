using BigBookstore.Application.BusinessLogic.Books.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Extensions;
using BigBookstore.Implementation.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Books.Commands
{
    public class UpdateBookCommand : IUpdateBookCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LetterId { get; set; }
        public Guid BindingTypeId { get; set; }
        public uint Pages { get; set; }
        public string Image { get; set; }
    }

    public class UpdateBookCommandHandler : RequestHandlerWithValidator<UpdateBookCommand, Unit, UpdateBookValidator>
    {
        public UpdateBookCommandHandler(IApplicationService service, UpdateBookValidator validator) : base(service, validator)
        {
        }

        protected override async  Task<Unit> ExecuteOperation(UpdateBookCommand request)
        {
            Book book = await this.GetBookById(request.Id);
            this.UpdateBooksValues(book, request);
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }

        private async  Task<Book> GetBookById(Guid id)
        {
            return await this.ApplicationService.Entity<Book>()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Letter)
                .Include(x => x.BindingType)
                .FirstAsync(x => x.IsActive && x.Id == id);
        }
        private void UpdateBooksValues(Book book, UpdateBookCommand request)
        {
            if(book == null || request == null)
            {
                throw new InvalidOperationException("Both Book and UpdateBookCommand references must not be null.");
            }

            if(request.Name.NotNullOrEmpty() && request.Name != book.Name)
            {
                book.Name = request.Name;
            }

            if(request.CategoryId.NotEmpty() &&   request.CategoryId != book.CategoryId)
            {
                book.CategoryId = request.CategoryId;
            }

            if(request.AuthorId.NotEmpty() && request.AuthorId != book.AuthorId)
            {
                book.AuthorId = request.AuthorId;
            }

            if(request.LetterId.NotEmpty() && request.LetterId != book.LetterId)
            {
                book.LetterId = request.LetterId;
            }
            
            if(request.Image.NotNullOrEmpty() && request.Image != book.Image)
            {
                book.Image = request.Image;
            }

            if(request.Pages > 0 && request.Pages != book.Pages)
            {
                book.Pages = request.Pages;
            }

        }
    }
}
