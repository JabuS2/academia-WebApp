using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia_WebApp.Controllers
{
    public class Exercicio : Controller
    {
        private readonly IExercicioRepositorio _exercicioRepositorio;
        public Exercicio(IExercicioRepositorio exercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
        }

        public IActionResult Index()
        {
            List<ExercicioModel> exercicios = _exercicioRepositorio.BuscarTodos();
            return View(exercicios);
        }
        public IActionResult CadastroExercicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarExercicio(ExercicioModel exercicio)
        {
            _exercicioRepositorio.Adicionar(exercicio);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            ExercicioModel exercicio = _exercicioRepositorio.ListarPorId(id);
            return View(exercicio);
        }


        public IActionResult Excluir(int id)
        {
            _exercicioRepositorio.Excluir(id);
            return RedirectToAction("CadastroExercicio");
        }

        public IActionResult Editar(int id)
        {
            ExercicioModel exercicio = _exercicioRepositorio.ListarPorId(id);
            return View("Editar", exercicio);
        }



        [HttpPost]
        public IActionResult Alterar(ExercicioModel exercicio)
        {
            _exercicioRepositorio.Atualizar(exercicio);
            return RedirectToAction("Index");
        }

    }
}
