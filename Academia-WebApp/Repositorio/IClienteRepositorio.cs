using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public interface IClienteRepositorio
    {
        List<ClienteModel> BuscarTodos();   
        ClienteModel Adicionar(ClienteModel cliente);
    }
}
