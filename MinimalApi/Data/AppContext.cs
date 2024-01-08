using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Models;

namespace MinimalApi.Data;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
{
    public DbSet<User>? Users { get; set; }
}