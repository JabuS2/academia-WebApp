using Academia_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia_WebApp.DBContext
{
    public class acadDbContext : DbContext
    {
        public acadDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ExercicioModel> Exercicio { get; set; }
        public DbSet<TreinoPersonalizadoModel> TreinoPersonalizado { get; set; }
        public DbSet<TreinoPersonalizadoExercicioModel> TreinoPersonalizadoExercicio { get; set; }
    }
}
