using Academia_WebApp.DBContext;
using Academia_WebApp.Models;

namespace Academia_WebApp.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly acadDbContext _acadDbContext;
        public ClienteRepositorio(acadDbContext acadDbContext) 
        {
            _acadDbContext = acadDbContext; 
        }
        public ClienteModel Adicionar(ClienteModel cliente)
        {
            //Graver no Banco de Dados
            _acadDbContext.Cliente.Add(cliente);
            _acadDbContext.SaveChanges();

            return cliente;
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _acadDbContext.Cliente.ToList();
        }
    }
}
