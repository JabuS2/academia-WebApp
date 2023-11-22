using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public interface IClienteRepositorio
    {
        List<ClienteModel> BuscarTodos();   
        ClienteModel Adicionar(ClienteModel cliente);

        ClienteModel Atualizar(ClienteModel cliente);

        bool Excluir(int id);

        ClienteModel ListarPorId(int id);

        List<ClienteTreinoViewModel> ObterClientesComTreinos();
    }
}
