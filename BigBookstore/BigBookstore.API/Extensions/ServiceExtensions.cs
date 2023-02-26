using BigBookstore.Implementation.BusinessLogic.Authors.Commands;
using BigBookstore.Implementation.BusinessLogic.Authors.Queries;
using BigBookstore.Implementation.BusinessLogic.BindingTypes.Commands;
using BigBookstore.Implementation.BusinessLogic.BindingTypes.Queries;
using BigBookstore.Implementation.BusinessLogic.Books.Commands;
using BigBookstore.Implementation.BusinessLogic.Books.Queries;
using BigBookstore.Implementation.BusinessLogic.Cartitems.Commands;
using BigBookstore.Implementation.BusinessLogic.Cartitems.Queries;
using BigBookstore.Implementation.BusinessLogic.Carts.Commands;
using BigBookstore.Implementation.BusinessLogic.Categories.Commands;
using BigBookstore.Implementation.BusinessLogic.Categories.Queries;
using BigBookstore.Implementation.BusinessLogic.Letters.Commands;
using BigBookstore.Implementation.BusinessLogic.Letters.Queries;
using BigBookstore.Implementation.BusinessLogic.Roles.Commands;
using BigBookstore.Implementation.BusinessLogic.Roles.Queries;
using BigBookstore.Implementation.BusinessLogic.Users.Commands;
using BigBookstore.Implementation.BusinessLogic.Users.Queries;
using BigBookstore.Implementation.Validators;
using MediatR;

namespace BigBookstore.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateAuthorValidator> () ;
            services.AddTransient<UpdateAuthorValidator> () ;
            services.AddTransient<CreateBindingTypeValidator> () ;
            services.AddTransient<UpdateBindingTypeValidator> () ;
            services.AddTransient<CreateCartItemValidator> () ;
            services.AddTransient<DeleteCartItemValidator> () ;
            services.AddTransient<CreateBookValidator> () ;
            services.AddTransient<UpdateBookValidator> () ;
            services.AddTransient<CreateCategoryValidator> () ;
            services.AddTransient<UpdateCategoryValidator> () ;
            services.AddTransient<CreateLetterValidator> () ;
            services.AddTransient<UpdateLetterValidator> () ;
            services.AddTransient<CreateRoleValidator> () ;
            services.AddTransient<UpdateRoleValidator> () ;
            services.AddTransient<CreateUserValidator> () ;
            services.AddTransient<UpdateUserValidator> () ;
        }

        public static void AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAuthorCommand).Assembly);
            services.AddMediatR(typeof(UpdateAuthorCommand).Assembly);
            services.AddMediatR(typeof(DeleteAuthorCommand).Assembly);

            services.AddMediatR(typeof(CreateBindingTypeCommand).Assembly);
            services.AddMediatR(typeof(UpdateBindingTypeCommand).Assembly);
            services.AddMediatR(typeof(DeleteBindingTypeCommand).Assembly);

            services.AddMediatR(typeof(CreateBookCommand).Assembly);
            services.AddMediatR(typeof(UpdateBookCommand).Assembly);
            services.AddMediatR(typeof(DeleteBookCommand).Assembly);

            services.AddMediatR(typeof(CreateCartItemCommand).Assembly);
            services.AddMediatR(typeof(DeleteCartItemCommand).Assembly);


            services.AddMediatR(typeof(CreateCartCommand).Assembly);
            services.AddMediatR(typeof(DeleteCartCommand).Assembly);
            services.AddMediatR(typeof(UpdateCartCommand).Assembly);

            services.AddMediatR(typeof(CreateCategoryCommand).Assembly);
            services.AddMediatR(typeof(UpdateCategoryCommand).Assembly);
            services.AddMediatR(typeof(DeleteCategoryCommand).Assembly);

            services.AddMediatR(typeof(CreateLetterCommand).Assembly);
            services.AddMediatR(typeof(UpdateLetterCommand).Assembly);
            services.AddMediatR(typeof(DeleteLetterCommand).Assembly);

            services.AddMediatR(typeof(CreateRoleCommand).Assembly);
            services.AddMediatR(typeof(UpdateRoleCommand).Assembly);
            services.AddMediatR(typeof(DeleteRoleCommand).Assembly);

            services.AddMediatR(typeof(CreateUserCommand).Assembly);
            services.AddMediatR(typeof(UpdateUserCommand).Assembly);
            services.AddMediatR(typeof(DeleteUserCommand).Assembly);
        }

        public static void AddQueries(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAuthorsQuery).Assembly);
            services.AddMediatR(typeof(GetAuthorByIdQuery).Assembly);

            services.AddMediatR(typeof(GetBindingTypesQuery).Assembly);
            services.AddMediatR(typeof(GetBindingTypeByIdQuery).Assembly);

            services.AddMediatR(typeof(GetBooksQuery).Assembly);

            services.AddMediatR(typeof(GetBookByIdQuery).Assembly);

            services.AddMediatR(typeof(GetCartItemsByCartQuery).Assembly);

            services.AddMediatR(typeof(GetCategoriesQuery).Assembly);
            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            services.AddMediatR(typeof(GetLettersQuery).Assembly);
            services.AddMediatR(typeof(GetLetterByIdQuery).Assembly);

            services.AddMediatR(typeof(GetRolesQuery).Assembly);
            services.AddMediatR(typeof(GetRoleByIdQuery).Assembly);

            services.AddMediatR(typeof(GetUsersQuery).Assembly);
            services.AddMediatR(typeof(GetUserByIdQuery).Assembly);
        }
    }
}
