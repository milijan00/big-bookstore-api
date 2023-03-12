using BigBookstore.API.Extensions;
using BigBookstore.Application.BusinessLogic;
using BigBookstore.Application.Services;
using BigBookstore.Implementation.Services;
using BigBookstore.Persistance;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BigBookStoreDbContext>();
builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddTransient<LoggerService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddValidators();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();
