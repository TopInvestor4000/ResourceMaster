using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
         : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            DotNetEnv.Env.TraversePath().Load();
            var user = DotNetEnv.Env.GetString("POSTGRES_USER");
            var database = DotNetEnv.Env.GetString("POSTGRES_DB");
            var password = DotNetEnv.Env.GetString("POSTGRES_PASSWORD");
            var host = DotNetEnv.Env.GetString("POSTGRES_HOST", "pg-svc");
            var connectionString = $"Host={host};Port=5432;Database={database};Username={user};Password={password}";
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }
       
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public DbSet<ProjectSkill> ProjectSkills { get; set; }

    public DbSet<ProjectResource> ProjectResources { get; set; }

    public DbSet<ResourceSkill> ResourceSkills { get; set; }
}
