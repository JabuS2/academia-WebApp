using Academia_WebApp.Controllers;
using Academia_WebApp.DBContext;
using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public class ExercicioRepositorio : IExercicioRepositorio
    {

        private readonly acadDbContext _acadDbContext;
        public ExercicioRepositorio(acadDbContext acadDbContext)
        {
            _acadDbContext = acadDbContext;
        }
        public ExercicioModel Adicionar(ExercicioModel exercicio)
        {
            //Graver no Banco de Dados
            _acadDbContext.Exercicio.Add(exercicio);
            _acadDbContext.SaveChanges();

            return exercicio;
        }

        public ExercicioModel ListarPorId(int id)
        {
            return _acadDbContext.Exercicio.FirstOrDefault(x => x.ExercicioId == id);
        }

        public ExercicioModel Atualizar(ExercicioModel exercicio)
        {
            ExercicioModel exercicioDB = ListarPorId(exercicio.ExercicioId);

            if (exercicioDB == null) throw new System.Exception("Houve um erro na atualização de fornecedor");

            exercicioDB.Nome = exercicio.Nome;
            exercicioDB.Descricao = exercicio.Descricao;
            exercicioDB.MusculoAlvo = exercicio.MusculoAlvo;
            exercicioDB.Equipamento = exercicio.Equipamento;

            _acadDbContext.Exercicio.Update(exercicioDB);
            _acadDbContext.SaveChanges();

            return exercicioDB;
        }

        public List<ExercicioModel> BuscarTodos()
        {
            return _acadDbContext.Exercicio.ToList();
        }

        public bool Excluir(int id)
        {
            ExercicioModel exercicioDB = ListarPorId(id);

            if (exercicioDB == null) throw new System.Exception("Houve um erro na deleção de contato");

            _acadDbContext.Exercicio.Remove(exercicioDB);
            _acadDbContext.SaveChanges();

            return true;
        }

        public List<ExercicioModel> ObterExerciciosPorMusculoAlvo(string musculoAlvo)
        {
            return _acadDbContext.Exercicio
                .Where(e => e.MusculoAlvo == musculoAlvo)
                .ToList();
        }

        public List<ExercicioModel> ObterTodosExercicios()
        {
            return _acadDbContext.Exercicio.ToList();
        }

    }

}

