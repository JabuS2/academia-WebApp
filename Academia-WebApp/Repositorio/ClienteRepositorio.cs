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

        public List<ClienteTreinoViewModel> ObterClientesComTreinos()
        {
            List<ClienteTreinoViewModel> clientesComTreinos = new List<ClienteTreinoViewModel>();

            // Obter todos os clientes do banco de dados
            List<ClienteModel> clientes = _acadDbContext.Cliente.ToList();

            // Para cada cliente, obter os treinos associados
            foreach (var cliente in clientes)
            {
                ClienteTreinoViewModel clienteComTreinos = new ClienteTreinoViewModel
                {
                    Cliente = cliente,
                    Treinos = _acadDbContext.TreinoPersonalizado
                                .Where(treino => treino.ClienteId == cliente.ClienteId)
                                .ToList()
                };

                clientesComTreinos.Add(clienteComTreinos);
            }

            return clientesComTreinos;
        }

    }
}
