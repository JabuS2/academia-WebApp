using System.Collections.Generic;
using System.Linq;
using Academia_WebApp.DBContext;
using Academia_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia_WebApp.Repositorio
{
    public class TreinoPersonalizadoExercicioRepositorio : ITreinoPersonalizadoExercicioRepositorio
    {
        private readonly acadDbContext _acadDbContext;

        public TreinoPersonalizadoExercicioRepositorio(acadDbContext acadDbContext)
        {
            _acadDbContext = acadDbContext;
        }

        public List<TreinoPersonalizadoExercicioModel> BuscarTodos()
        {
            return _acadDbContext.TreinoPersonalizadoExercicio.ToList();
        }

        public TreinoPersonalizadoExercicioModel ListarPorId(int id)
        {
            return _acadDbContext.TreinoPersonalizadoExercicio.Find(id);
        }

        public void Adicionar(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio)
        {
            _acadDbContext.TreinoPersonalizadoExercicio.Add(treinoPersonalizadoExercicio);
            _acadDbContext.SaveChanges();
        }

        public void Atualizar(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio)
        {
            _acadDbContext.Entry(treinoPersonalizadoExercicio).State = EntityState.Modified;
            _acadDbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio = _acadDbContext.TreinoPersonalizadoExercicio.Find(id);
            _acadDbContext.TreinoPersonalizadoExercicio.Remove(treinoPersonalizadoExercicio);
            _acadDbContext.SaveChanges();
        }

        public List<TreinoPersonalizadoExercicioModel> ObterTreinosPorCliente(int clienteId)
        {
            // Lógica para obter treinos personalizados exercícios por cliente
            return _acadDbContext.TreinoPersonalizadoExercicio
                .Where(tpe => tpe.TreinoPersonalizado.ClienteId == clienteId)
                .ToList();
        }
        public List<ExercicioModel> ObterExerciciosPorMusculoAlvo(string musculoAlvo)
        {
            return _acadDbContext.Exercicio.Where(e => e.MusculoAlvo == musculoAlvo).ToList();
        }

        public List<TreinoPersonalizadoExercicioModel> BuscarPorClienteId(int clienteId)
        {
            return _acadDbContext.TreinoPersonalizadoExercicio
                .Where(te => te.TreinoPersonalizado.ClienteId == clienteId)
                .ToList();
        }

        public List<TreinoPersonalizadoExercicioModel> BuscarPorTreinoPersonalizadoId(int treinoPersonalizadoId)
        {
            return _acadDbContext.TreinoPersonalizadoExercicio
                .Include(tpe => tpe.Exercicio)
                .Where(tpe => tpe.TreinoPersonalizadoId == treinoPersonalizadoId)
                .ToList();
        }

    }
}
