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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>()
                .HasMany(c => c.TreinosPersonalizados)
                .WithOne(tp => tp.Cliente)
                .HasForeignKey(tp => tp.ClienteId);

            modelBuilder.Entity<TreinoPersonalizadoModel>()
                .HasMany(tp => tp.TreinosPersonalizadosExercicios)
                .WithOne(tpe => tpe.TreinoPersonalizado)
                .HasForeignKey(tpe => tpe.TreinoPersonalizadoId);

            modelBuilder.Entity<ExercicioModel>()
                .HasMany(e => e.TreinosPersonalizadosExercicios)
                .WithOne(tpe => tpe.Exercicio)
                .HasForeignKey(tpe => tpe.ExercicioId);
        }
    }
}
