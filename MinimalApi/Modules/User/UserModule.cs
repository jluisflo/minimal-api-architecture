using Carter;
using MinimalApi.Modules.User.Handlers;

namespace MinimalApi.Modules.User;

public class UserModule : CarterModule
{
    public UserModule() : base(basePath: "users")
    {
        IncludeInOpenApi();
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllUsers.Handle);
        app.MapGet("/{id:int}", GetUser.Handle);
        app.MapPost("/", SaveUser.Handle);
        app.MapDelete("/{id:int}", DeleteUser.Handle);
    }
}