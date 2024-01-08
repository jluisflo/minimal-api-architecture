using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Models;
using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Data.Repositories;

public class UserRepository(AppContext context) : IUserRepository
{
    public Task<List<User>> GetAll() => context.Users!.ToListAsync();

    public Task<User> GetById(int id) => context.Users!.FirstOrDefaultAsync(u => u.Id.Equals(id))!;

    public Task Save(User user)
    {
        context.Users!.Add(user);
        return context.SaveChangesAsync();
    }

    public Task Delete(User user)
    {
        context.Users!.Remove(user);
        return context.SaveChangesAsync();
    }
    
    public Task<bool> Exists(int id) => context.Users!.AnyAsync(u => u.Id.Equals(id));
}