using Carter.ModelBinding;
using Mapster;
using MinimalApi.Data.Repositories.Interfaces;
using MinimalApi.Modules.User.Dtos;

namespace MinimalApi.Modules.User.Handlers;

public static class SaveUser
{
    public static async Task<IResult> Handle(
        AddUserDto newUser,
        HttpContext ctx,
        IUserRepository userRepository)
    {
        var result = ctx.Request.Validate(newUser);
        if (!result.IsValid)
            return Results.UnprocessableEntity(result.GetValidationProblems());

        var user = newUser.Adapt<Data.Models.User>();
        await userRepository.Save(user);
        return Results.Ok("User saved successfully");
    }
}