using go_horse_voos_comerciais.Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;

namespace go_horse_voos_comerciais.Domain.Reserva
{
    public class ReservasRepository : Repository<Reservas>
    {
        public ReservasRepository(ApiGhvcDbContext context) : base(context) { }
    }
}
