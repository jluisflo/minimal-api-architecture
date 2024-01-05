using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Models;
using MinimalApi.Data.Repositories.Interfaces;

namespace MinimalApi.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;

    public UserRepository(AppContext context)
    {
        _context = context;
    }

    public Task<List<User>> GetAll() => _context.Users!.ToListAsync();

    public Task<User> GetById(int id) => _context.Users!.FirstOrDefaultAsync(u => u.Id.Equals(id))!;

    public Task Save(User user)
    {
        _context.Users!.Add(user);
        return _context.SaveChangesAsync();
    }

    public Task Delete(User user)
    {
        _context.Users!.Remove(user);
        return _context.SaveChangesAsync();
    }
    
    public Task<bool> Exists(int id) => _context.Users!.AnyAsync(u => u.Id.Equals(id));
}