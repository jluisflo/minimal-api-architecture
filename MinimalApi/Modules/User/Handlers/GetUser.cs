using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Modules.User.Handlers;

public static class GetUser
{
    public static Task<Data.Models.User> Handle(int id, IUserRepository userRepository)
    {
        return userRepository.GetById(id);
    }
}