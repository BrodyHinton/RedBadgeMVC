using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.TeamServices;
using RedBadge.MVC.Models;
using RedBadge.Models.TeamModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]

    public class TeamController : Controller
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _teamService.GetAllTeamsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _teamService.GetTeamByIdAsync(id));
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
        public async Task<IActionResult> Post(TeamCreate team)
        {
            if(!ModelState.IsValid)return BadRequest(team);
            if(await _teamService.CreateTeamAsync(team))
            return RedirectToAction(nameof(Index));
            else
            return View(team);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            var teamEdit = new TeamUpdate
            {
                Id = team.Id,
                Name = team.Name,
                Wins = team.Wins,
                Loses = team.Loses,
                Championships = team.Championships,
                LeagueId = team.LeagueId
            };
            return View(teamEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _teamService.UpdateTeamAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var team = await _teamService.GetTeamByIdAsync(id.Value);
            return View(team);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _teamService.DeleteTeamAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}