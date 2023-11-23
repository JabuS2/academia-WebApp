using Academia_WebApp.Models;
using Academia_WebApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Academia_WebApp.Controllers
{
    public class TreinoPersonalizadoExercicioController : Controller
    {
        private readonly ITreinoPersonalizadoExercicioRepositorio _treinoPersonalizadoExercicioRepositorio;
        private readonly IExercicioRepositorio _exercicioRepositorio;

        public TreinoPersonalizadoExercicioController(ITreinoPersonalizadoExercicioRepositorio treinoPersonalizadoExercicioRepositorio, IExercicioRepositorio exercicioRepositorio)
        {
            _treinoPersonalizadoExercicioRepositorio = treinoPersonalizadoExercicioRepositorio;
            _exercicioRepositorio = exercicioRepositorio;
        }

        private List<ClienteTreinoViewModel> TransformarTreinosParaClienteTreinoViewModel(List<TreinoPersonalizadoExercicioModel> treinosExercicios, int clienteId)
        {
            // Implemente a lógica para transformar os treinos conforme necessário
            // ...

            return new List<ClienteTreinoViewModel>(); // Altere isso conforme a lógica real
        }

        public IActionResult Index(int treinoPersonalizadoId)
        {
            List<TreinoPersonalizadoExercicioModel> treinosExercicios = _treinoPersonalizadoExercicioRepositorio.BuscarPorTreinoPersonalizadoId(treinoPersonalizadoId);

            // Crie uma instância de ClienteTreinoViewModel
            var clienteComTreinos = new ClienteTreinoViewModel
            {
                // Adicione o ClienteId correspondente ao seu TreinoPersonalizado
                Cliente = new ClienteModel { ClienteId = treinosExercicios.FirstOrDefault()?.TreinoPersonalizado?.ClienteId ?? 0 },
                TreinosExcercicio = treinosExercicios
            };

            return View(new List<ClienteTreinoViewModel> { clienteComTreinos });
        }

        public IActionResult CadastroTreinoExercicio(int treinoPersonalizadoId)
        {
            ViewBag.TreinoPersonalizadoId = treinoPersonalizadoId;

            List<ExercicioModel> listaExercicio = _exercicioRepositorio.ObterTodosExercicios();

            var model = new TreinoPersonalizadoExercicioModel
            {
                ListaExercicio = listaExercicio
            };

            return View("CadastroTreinoExercicio", model);
        }

        public IActionResult ExerciciosPorMusculoAlvo(string musculoAlvo)
        {
            List<ExercicioModel> exercicios = _exercicioRepositorio.ObterExerciciosPorMusculoAlvo(musculoAlvo);

            return Json(exercicios);
        }

        [HttpPost]
        public IActionResult CadastrarTreinoExercicio(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio)
        {
            treinoPersonalizadoExercicio.TreinoPersonalizadoId = Convert.ToInt32(Request.Form["TreinoPersonalizadoId"]);

            _treinoPersonalizadoExercicioRepositorio.Adicionar(treinoPersonalizadoExercicio);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio = _treinoPersonalizadoExercicioRepositorio.ListarPorId(id);
            return View(treinoPersonalizadoExercicio);
        }

        public IActionResult Excluir(int id)
        {
            _treinoPersonalizadoExercicioRepositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio = _treinoPersonalizadoExercicioRepositorio.ListarPorId(id);
            return View("Editar", treinoPersonalizadoExercicio);
        }

        [HttpPost]
        public IActionResult Alterar(TreinoPersonalizadoExercicioModel treinoPersonalizadoExercicio)
        {
            _treinoPersonalizadoExercicioRepositorio.Atualizar(treinoPersonalizadoExercicio);
            return RedirectToAction("Index");
        }
    }
}
