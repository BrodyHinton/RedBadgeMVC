using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.GameServices;
using RedBadge.MVC.Models;
using RedBadge.Models.GameModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]

    public class GameController: Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _gameService.GetAllGamesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _gameService.GetGameByIdAsync(id));
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            return View();
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(GameCreate game)
        {
            if(!ModelState.IsValid)return BadRequest(game);
            if(await _gameService.CreateGameAsync(game))
            return RedirectToAction(nameof(Index));
            else
            return View(game);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            var gameEdit = new GameUpdate
            {
                Id = game.Id,
                Date = game.Date,
                LeagueName = game.LeagueName,
                HomeTeamId = game.HomeTeamId,
                AwayTeamId = game.AwayTeamId,
                HomeTeamScore = game.HomeTeamScore,
                AwayTeamScore = game.AwayTeamScore,
                HighlightLink = game.HighlightLink
            };
            return View(gameEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GameUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _gameService.UpdateGameAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var game = await _gameService.GetGameByIdAsync(id.Value);
            return View(game);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _gameService.DeleteGameAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}