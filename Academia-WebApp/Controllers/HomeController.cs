using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Academia_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public HomeController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            List<ClienteModel> Clientes = _clienteRepositorio.BuscarTodos();
            return View(Clientes);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}