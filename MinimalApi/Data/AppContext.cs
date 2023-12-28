using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Models;

namespace MinimalApi.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
}