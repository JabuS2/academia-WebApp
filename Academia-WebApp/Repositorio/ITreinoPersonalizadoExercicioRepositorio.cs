using Academia_WebApp.Models;

public interface ITreinoPersonalizadoExercicioRepositorio
{
    List<TreinoPersonalizadoExercicioModel> BuscarTodos();
    TreinoPersonalizadoExercicioModel ListarPorId(int id);
    void Adicionar(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio);
    void Atualizar(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio);
    void Excluir(int id);
    List<TreinoPersonalizadoExercicioModel> ObterTreinosPorCliente(int clienteId);
    List<ExercicioModel> ObterExerciciosPorMusculoAlvo(string musculoAlvo);
    List<TreinoPersonalizadoExercicioModel> BuscarPorClienteId(int clienteId);

    List<TreinoPersonalizadoExercicioModel> BuscarPorTreinoPersonalizadoId(int treinoPersonalizadoId);


}
