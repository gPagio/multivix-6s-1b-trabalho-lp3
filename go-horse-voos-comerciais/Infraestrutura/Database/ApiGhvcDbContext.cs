using go_horse_voos_comerciais.Domain.Passagem;
using go_horse_voos_comerciais.Domain.Reserva;
using go_horse_voos_comerciais.Domain.Voo;
using Microsoft.EntityFrameworkCore;

public class ApiGhvcDbContext : DbContext
{
    public DbSet<Locais> Locais { get; set; }
    public DbSet<CompanhiasOperantes> CompanhiasOperantes { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Voos> Voos { get; set; }
    public DbSet<Reservas> Reservas { get; set; }
    public DbSet<Passagens> Passagens { get; set; }

    private static readonly string? host = Environment.GetEnvironmentVariable("GHVC_DB_HOST");
    private static readonly string? port = Environment.GetEnvironmentVariable("GHVC_DB_PORT");
    private static readonly string? database = Environment.GetEnvironmentVariable("GHVC_DB_DATABASE");
    private static readonly string? username = Environment.GetEnvironmentVariable("GHVC_DB_USER");
    private static readonly string? password = Environment.GetEnvironmentVariable("GHVC_DB_PASSWORD");

    private static readonly string? connectionString = $"Server={host};Port={port};Database={database};User Id={username};Password={password}";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Voos>()
            .HasMany(voo => voo.Reservas)
            .WithOne(voo => voo.Voo)
            .HasForeignKey(voo => voo.IdVoo)
            .HasPrincipalKey(voo => voo.Id);

        modelBuilder.Entity<Reservas>()
            .HasMany(reserva => reserva.Passagens)
            .WithOne(reserva => reserva.Reserva)
            .HasForeignKey(reserva => reserva.IdReserva)
            .HasPrincipalKey(reserva => reserva.Id);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(connectionString);
}
