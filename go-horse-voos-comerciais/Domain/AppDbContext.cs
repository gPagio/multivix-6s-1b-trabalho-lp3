using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Local> Cachorros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var host = Environment.GetEnvironmentVariable("GHVC_DB_HOST");
        var database = Environment.GetEnvironmentVariable("GHVC_DB_DATABASE");
        var username = Environment.GetEnvironmentVariable("GHVC_DB_USER");
        var password = Environment.GetEnvironmentVariable("GHVC_DB_PASSWORD");

        var connectionString = $"Host={host};Database={database};Username={username};Password={password}";

        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
        });
    }
}
