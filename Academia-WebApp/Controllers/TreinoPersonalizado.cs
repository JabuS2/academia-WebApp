using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia_WebApp.Controllers
{
    public class TreinoPersonalizado : Controller
    {
        private readonly ITreinoRepositorio _TreinoRepositorio;
        public TreinoPersonalizado(ITreinoRepositorio treinoRepositorio)
        {
            _TreinoRepositorio = treinoRepositorio;
        }

        public IActionResult Index()
        {
            List<TreinoPersonalizadoModel> treinos = _TreinoRepositorio.BuscarTodos();
            return View(treinos);
        }
        public IActionResult CadastroTreino(int clienteId)
        {
            ViewBag.ClienteId = clienteId;
            return View();
        }


        [HttpPost]
        [HttpPost]
        public IActionResult CadastrarTreino(TreinoPersonalizadoModel treino)
        {
            _TreinoRepositorio.Adicionar(treino);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Apagar(int id)
        {
            TreinoPersonalizadoModel treino = _TreinoRepositorio.ListarPorId(id);
            return View(treino);
        }


        public IActionResult Excluir(int id)
        {
            _TreinoRepositorio.Excluir(id);
            return RedirectToAction("CadastroTreino");
        }

        public IActionResult Editar(int id)
        {
            TreinoPersonalizadoModel treino = _TreinoRepositorio.ListarPorId(id);
            return View("Editar", treino);
        }



        [HttpPost]
        public IActionResult Alterar(TreinoPersonalizadoModel treino)
        {
            _TreinoRepositorio.Atualizar(treino);
            return RedirectToAction("Index");
        }
    }
}