using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Data;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.TraversePath().Load();
        var user = DotNetEnv.Env.GetString("POSTGRES_USER");
        var database = DotNetEnv.Env.GetString("POSTGRES_DB");
        var password = DotNetEnv.Env.GetString("POSTGRES_PASSWORD");
        var host = DotNetEnv.Env.GetString("POSTGRES_HOST", "pg-svc");
        var connectionString = $"Host={host};Port=5432;Database={database};Username={user};Password={password}";
        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Skill> Skills { get; set; }
}
