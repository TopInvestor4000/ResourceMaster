using dotenv.net;
using Microsoft.EntityFrameworkCore;
using ResourceMaster.Models;

namespace ResourceMaster.Data;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();

        var user = Environment.GetEnvironmentVariable(envVars["POSTGRES_USER"]);
        var database = Environment.GetEnvironmentVariable(envVars["POSTGRES_DB"]);
        var password = Environment.GetEnvironmentVariable(envVars["POSTGRES_PASSWORD"]);

        var connectionString = $"Host=pg-svc;Port=5432;Database={database};Username={user};Password={password}";

        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<MyTable> MyTables { get; set; }
}
