using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.PlayerServices;
using RedBadge.MVC.Models;
using RedBadge.Models.PlayerModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]

    public class PlayerController : Controller
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _playerService.GetAllPlayersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _playerService.GetPlayerByIdAsync(id));
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
        public async Task<IActionResult> Post(PlayerCreate player)
        {
            if(!ModelState.IsValid)return BadRequest(player);
            if(await _playerService.CreatePlayerAsync(player))
            return RedirectToAction(nameof(Index));
            else
            return View(player);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            var playerEdit = new PlayerUpdate
            {
                Id = player.Id,
                Name = player.Name,
                Championships = player.Championships,
                TeamId = player.TeamId
            };
            return View(playerEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlayerUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _playerService.UpdatePlayerAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id.Value);
            return View(player);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _playerService.DeletePlayerAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}