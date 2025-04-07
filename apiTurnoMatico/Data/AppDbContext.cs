using Microsoft.EntityFrameworkCore;
using apiTurnoMatico.Model.DB;

namespace apiTurnoMatico.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Oficina> Oficinas { get; set; }
    }
}
