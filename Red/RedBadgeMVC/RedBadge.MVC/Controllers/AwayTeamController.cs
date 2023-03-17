using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.AwayTeamServices;
using RedBadge.MVC.Models;
using RedBadge.Models.AwayTeamModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]

    public class AwayTeamController : Controller
    {
        private IAwayTeamService _awayteamService;

        public AwayTeamController(IAwayTeamService awayteamService)
        {
            _awayteamService = awayteamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _awayteamService.GetAllAwayTeamsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _awayteamService.GetAwayTeamByIdAsync(id));
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
        public async Task<IActionResult> Post(AwayTeamCreate awayteam)
        {
            if(!ModelState.IsValid)return BadRequest(awayteam);
            if(await _awayteamService.CreateAwayTeamAsync(awayteam))
            return RedirectToAction(nameof(Index));
            else
            return View(awayteam);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var awayteam = await _awayteamService.GetAwayTeamByIdAsync(id);
            var awayteamEdit = new AwayTeamUpdate
            {
                Id = awayteam.Id,
                Name = awayteam.Name
            };
            return View(awayteamEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AwayTeamUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _awayteamService.UpdateAwayTeamAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var awayteam = await _awayteamService.GetAwayTeamByIdAsync(id.Value);
            return View(awayteam);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _awayteamService.DeleteAwayTeamAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}