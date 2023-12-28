using Carter;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Repositories;
using MinimalApi.Data.Repositories.Interfaces;
using AppContext = MinimalApi.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddDbContext<AppContext>(options => options.UseInMemoryDatabase(databaseName: "users"));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();