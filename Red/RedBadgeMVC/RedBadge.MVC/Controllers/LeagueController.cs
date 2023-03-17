using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.LeagueServices;
using RedBadge.MVC.Models;
using RedBadge.Models.LeagueModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]
    
    public class LeagueController : Controller
    {
        private ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _leagueService.GetAllLeaguesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _leagueService.GetLeagueByIdAsync(id));
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
        public async Task<IActionResult> Post(LeagueCreate league)
        {
            if(!ModelState.IsValid)return BadRequest(league);
            if(await _leagueService.CreateLeagueAsync(league))
            return RedirectToAction(nameof(Index));
            else
            return View(league);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var league = await _leagueService.GetLeagueByIdAsync(id);
            var leagueEdit = new LeagueUpdate
            {
                Id = league.Id,
                Name = league.Name
            };
            return View(leagueEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeagueUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _leagueService.UpdateLeagueAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var league = await _leagueService.GetLeagueByIdAsync(id.Value);
            return View(league);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _leagueService.DeleteLeagueAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}