using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public interface IExercicioRepositorio
    {
        List<ExercicioModel> BuscarTodos();
        ExercicioModel Adicionar(ExercicioModel exercicio);

        ExercicioModel Atualizar(ExercicioModel exercicio);

        bool Excluir(int id);

        ExercicioModel ListarPorId(int id);

    }
}
