using Academia_WebApp.DBContext;
using Academia_WebApp.Models;
using Microsoft.EntityFrameworkCore;

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

        public ClienteModel ListarPorId(int id)
        {
            return _acadDbContext.Cliente.FirstOrDefault(x => x.ClienteId == id);
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.ClienteId);

            if (clienteDB == null) throw new System.Exception("Houve um erro na atualização de fornecedor");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Email = cliente.Email;
            clienteDB.Plano = cliente.Plano;
            clienteDB.DataCadastro = cliente.DataCadastro;
            clienteDB.DataNascimento = cliente.DataNascimento ;

            _acadDbContext.Cliente.Update(clienteDB);
            _acadDbContext.SaveChanges();

            return clienteDB;
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _acadDbContext.Cliente.ToList();
        }

        public bool Excluir(int id)
        {
            ClienteModel clienteDB = ListarPorId(id);

            if (clienteDB == null) throw new System.Exception("Houve um erro na deleção de contato");

            _acadDbContext.Cliente.Remove(clienteDB);
            _acadDbContext.SaveChanges();

            return true;
        }

    }
}
