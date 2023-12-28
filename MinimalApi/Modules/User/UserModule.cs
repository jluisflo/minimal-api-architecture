using Carter;
using Carter.ModelBinding;
using Mapster;
using MinimalApi.Data.Repositories.Interfaces;
using MinimalApi.Modules.User.Dtos;

namespace MinimalApi.Modules.User;

public class UserModule : CarterModule
{
    public UserModule() : base(basePath: "users")
    {
        IncludeInOpenApi();
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", (IUserRepository userRepository) => userRepository.GetAll());
        app.MapGet("/{id}", (int id, IUserRepository userRepository) => userRepository.GetById(id));
        app.MapPost("/", async (SaveUserDto newUser, HttpContext ctx, IUserRepository userRepository) =>
        {
            var result = ctx.Request.Validate(newUser);
            if (!result.IsValid)
            {
                return Results.UnprocessableEntity(result.GetFormattedErrors());
            }
            var user = newUser.Adapt<Data.Models.User>();
            await userRepository.Save(user);
            return Results.Ok("User saved successfully");
        });
        app.MapDelete("/{id}", async (int id, IUserRepository userRepository) =>
        {
            await userRepository.Delete(new Data.Models.User { Id = id });
            return Results.Ok("User deleted successfully");
        });
    }
}