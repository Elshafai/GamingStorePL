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
            return View();
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
    }
}
