using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Modules.User.Handlers;

public static class GetAllUsers
{
    public static Task<List<Data.Models.User>> Handle(IUserRepository userRepository)
    {
        return userRepository.GetAll();
    }
}