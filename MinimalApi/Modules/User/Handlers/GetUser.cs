using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Modules.User.Handlers;

public static class GetUser
{
    public static async Task<IResult> Handle(int id, IUserRepository userRepository)
    {
        var exists = await userRepository.Exists(id);
        if (!exists)
        {
            return Results.BadRequest(new { Message = "User not found" });
        }

        var user = await userRepository.GetById(id);
        return Results.Ok(user);
    }
}