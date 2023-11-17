using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia_WebApp.Controllers
{
    public class Cliente : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public Cliente(IClienteRepositorio clienteRepositorio) 
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
