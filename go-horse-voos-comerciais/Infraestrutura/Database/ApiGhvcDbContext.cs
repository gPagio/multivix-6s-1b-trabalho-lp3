using Microsoft.EntityFrameworkCore;

public class ApiGhvcDbContext : DbContext
{
    public DbSet<Locais> Locais { get; set; }
    public DbSet<CompanhiasOperantes> CompanhiasOperantes { get; set; }

    private static readonly string? host = Environment.GetEnvironmentVariable("GHVC_DB_HOST");
    private static readonly string? port = Environment.GetEnvironmentVariable("GHVC_DB_PORT");
    private static readonly string? database = Environment.GetEnvironmentVariable("GHVC_DB_DATABASE");
    private static readonly string? username = Environment.GetEnvironmentVariable("GHVC_DB_USER");
    private static readonly string? password = Environment.GetEnvironmentVariable("GHVC_DB_PASSWORD");

    private static readonly string? connectionString = $"Server={host};Port={port};Database={database};User Id={username};Password={password}";

    //Sobrescrever o metodo de configuração do banco
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(connectionString);
}
