
using go_horse_voos_comerciais.Domain.CompanhiaOperante;
using go_horse_voos_comerciais.Domain.Local;
using go_horse_voos_comerciais.Infraestrutura.Middleware;
using go_horse_voos_comerciais.Infraestrutura.Repositories;

namespace go_horse_voos_comerciais;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApiGhvcDbContext>();

        // Registra o repositório genérico com o tipo da entidade específica
        builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        // Registra o repositório específico (apenas necessário caso o repositório tenha um método específico para a entidade)
        //builder.Services.AddTransient<ILocaisRepository, LocaisRepository>();

        // Registra o serviço
        builder.Services.AddScoped<ILocaisService, LocaisService>();
        builder.Services.AddScoped<ICompanhiasOperantesService, CompanhiasOperantesService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
