using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Modules.User.Handlers;

public static class DeleteUser
{
    public static async Task<IResult> Handle(int id, IUserRepository userRepository)
    {
        await userRepository.Delete(new Data.Models.User { Id = id });
        return Results.Ok("User deleted successfully");
    }
}