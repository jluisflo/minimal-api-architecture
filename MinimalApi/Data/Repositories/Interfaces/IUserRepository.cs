using MinimalApi.Data.Models;

namespace MinimalApi.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAll();
    public Task<User> GetById(int id);
    public Task Save(User user);
    public Task Delete(User id);
}