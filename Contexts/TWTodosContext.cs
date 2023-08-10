using Microsoft.EntityFrameworkCore;
using TWTodos.Models;

namespace TWTodos.Contexts;

public class TWTodosContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    private readonly IConfiguration _configuration;

    public TWTodosContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
        optionsBuilder.UseMySql(_configuration.GetConnectionString("Default"), serverVersion);
    }
}