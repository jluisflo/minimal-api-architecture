using Mapster;
using MinimalApi.Data.Repositories.Interfaces;
using MinimalApi.Modules.User.Dtos;

namespace MinimalApi.Modules.User.Handlers;

public static class AddUser
{
    public static async Task<IResult> Handle(
        AddUserDto newUser,
        HttpContext ctx,
        IUserRepository userRepository)
    {
        var user = newUser.Adapt<Data.Models.User>();
        await userRepository.Save(user);
        return Results.Ok("User saved successfully");
    }
}