using MinimalApi.Modules.User.Handlers;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace MinimalApi.Modules.User;

public static class UserModule
{
    public static void UseUserModule(this WebApplication app)
    {
        var mapGroup = app.MapGroup("/users")
            .AddFluentValidationAutoValidation()
            .WithOpenApi();
        mapGroup.MapGet("/", GetAllUsers.Handle);
        mapGroup.MapGet("/{id:int}", GetUser.Handle);
        mapGroup.MapPost("/", AddUser.Handle);
        mapGroup.MapDelete("/{id:int}", DeleteUser.Handle);
    }
}