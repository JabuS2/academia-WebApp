using Academia_WebApp.DBContext;
using Academia_WebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace Academia_WebApp.Repositorio
{
    public class TreinoRepositorio : ITreinoRepositorio
    {
        private readonly acadDbContext _acadDbContext;
        public TreinoRepositorio(acadDbContext acadDbContext)
        {
            _acadDbContext = acadDbContext;
        }
        public TreinoPersonalizadoModel Adicionar(TreinoPersonalizadoModel treino)
        {
            //Graver no Banco de Dados
            _acadDbContext.TreinoPersonalizado.Add(treino);
            _acadDbContext.SaveChanges();

            return treino;
        }

        public TreinoPersonalizadoModel ListarPorId(int id)
        {
            return _acadDbContext.TreinoPersonalizado.FirstOrDefault(x => x.TreinoPersonalizadoId == id);
        }

        public TreinoPersonalizadoModel Atualizar(TreinoPersonalizadoModel treino)
        {
            TreinoPersonalizadoModel treinoDB = ListarPorId(treino.TreinoPersonalizadoId);

            if (treinoDB == null) throw new System.Exception("Houve um erro na atualização de fornecedor");

            treinoDB.DataCriacao = treino.DataCriacao;
            treinoDB.Observacoes = treino.Observacoes;

            _acadDbContext.TreinoPersonalizado.Update(treinoDB);
            _acadDbContext.SaveChanges();

            return treinoDB;
        }

        public List<TreinoPersonalizadoModel> BuscarTodos()
        {
            return _acadDbContext.TreinoPersonalizado.ToList();
        }

        public bool Excluir(int id)
        {
            TreinoPersonalizadoModel treinoDB = ListarPorId(id);

            if (treinoDB == null) throw new System.Exception("Houve um erro na deleção de contato");

            _acadDbContext.TreinoPersonalizado.Remove(treinoDB);
            _acadDbContext.SaveChanges();

            return true;
        }

        public List<TreinoPersonalizadoModel> ObterTreinosPorCliente(int clienteId)
        {
            // Aqui estamos assumindo que existe um relacionamento entre ClienteModel e TreinoPersonalizadoModel
            // e que há uma propriedade chamada ClienteId em TreinoPersonalizadoModel para representar essa relação.
            return _acadDbContext.TreinoPersonalizado
                .Where(treino => treino.ClienteId == clienteId)
                .ToList();
        }


    }
}
