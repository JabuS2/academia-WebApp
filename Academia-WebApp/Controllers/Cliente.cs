using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia_WebApp.Controllers
{
    public class Cliente : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ITreinoRepositorio _treinoRepositorio;

        public Cliente(IClienteRepositorio clienteRepositorio, ITreinoRepositorio treinoRepositorio) 
        {
            _clienteRepositorio = clienteRepositorio;
            _treinoRepositorio = treinoRepositorio;
        }

        private List<ClienteTreinoViewModel> TransformarTreinosParaClienteTreinoViewModel(List<TreinoPersonalizadoModel> treinos, int clienteId)
        {
            List<ClienteTreinoViewModel> clientesComTreinos = treinos
                .Select(treino => new ClienteTreinoViewModel
                {
                    Cliente = _clienteRepositorio.ListarPorId(clienteId), // Obtém os dados do cliente
                    Treinos = new List<TreinoPersonalizadoModel> { treino }
                })
                .ToList();

            return clientesComTreinos;
        }



        public IActionResult Index(int clienteId)
        {
            List<TreinoPersonalizadoModel> treinos = _treinoRepositorio.ObterTreinosPorCliente(clienteId);

            List<ClienteTreinoViewModel> clienteComTreinos = TransformarTreinosParaClienteTreinoViewModel(treinos, clienteId);

            return View(clienteComTreinos);
        }



        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteModel cliente)
        {
            _clienteRepositorio.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }


        public IActionResult Excluir(int id)
        {
            _clienteRepositorio.Excluir(id);
            return RedirectToAction("CadastroCliente");
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View("Editar", cliente);
        }


        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            _clienteRepositorio.Atualizar(cliente);
            return RedirectToAction("CadastroCliente");
        }

    }
}
