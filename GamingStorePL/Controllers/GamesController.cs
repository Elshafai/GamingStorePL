using BLL.Interfaces;
using BLL.Repositories;
using BLL.Specification;
using DAL.Models;
using GamingStorePL.Services;
using GamingStorePL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamingStorePL.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public IActionResult Index()
        {
            var games = gameService.GetAllGames();
            return View(games);
        }
        public IActionResult Create()
        {
            var model = gameService.PrepareCreateGameVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameVM model)
        {
            if (!ModelState.IsValid)
            {
                var prepared = gameService.PrepareCreateGameVM();
                return View(model);
            }
            gameService.CreateGame(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var game = gameService.GetGameById(id);
            if (game is null) return NotFound();
            return View(game);
        }
        public IActionResult Edit(int id)
        {
            var model = gameService.PrepareEditGameVM(id);
            if (model is null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditGameVM model)
        {
            if (!ModelState.IsValid)
            {
                var prepared = gameService.PrepareEditGameVM(model.Id);
                if (prepared is null) return NotFound();

                model.Categories = prepared.Categories;
                model.Devices = prepared.Devices;
                model.CurrentCover = prepared.CurrentCover;

                return View(model);
            }

            gameService.UpdateGame(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            gameService.DeleteGame(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
