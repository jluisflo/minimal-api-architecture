using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Commons.Validation;
using MinimalApi.Data.Repositories;
using MinimalApi.Data.Repositories.Interfaces;
using MinimalApi.Modules.User;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
using AppContext = MinimalApi.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppContext>(options => options.UseInMemoryDatabase(databaseName: "users"));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation(config => config.OverrideDefaultResultFactoryWith<CustomResultFactory>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure application modules
app.UseUserModule();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();