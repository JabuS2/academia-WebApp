using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public interface ITreinoRepositorio
    {
        List<TreinoPersonalizadoModel> BuscarTodos();
        TreinoPersonalizadoModel Adicionar(TreinoPersonalizadoModel treino);

        TreinoPersonalizadoModel Atualizar(TreinoPersonalizadoModel treino);

        bool Excluir(int id);

        TreinoPersonalizadoModel ListarPorId(int id);

        List<TreinoPersonalizadoModel> ObterTreinosPorCliente(int clienteId);
    }
}
