using Microsoft.EntityFrameworkCore;
using RCloud.Models;

namespace RCloud.DataAccess
{
    public class UserDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public UserDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }
}
}