using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.Commons.Validation;
using MinimalApi.Data.Repositories;
using MinimalApi.Data.Repositories.Interfaces;
using MinimalApi.Modules.User;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
using AppContext = MinimalApi.Data.AppContext;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppContext>(options => options.UseInMemoryDatabase(databaseName: "users"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation(config => config.OverrideDefaultResultFactoryWith<CustomResultFactory>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key Authorization header using the ApiKey scheme. Example: \"X-API-KEY: {apiKey}\"",
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
            },
            Array.Empty<string>()
        }
    });
});

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