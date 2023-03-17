using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.HomeTeamServices;
using RedBadge.MVC.Models;
using RedBadge.Models.HomeTeamModels;

namespace RedBadge.MVC.Controllers
{
    [Route("[controller]")]

    public class HomeTeamController : Controller
    {
        private IHomeTeamService _hometeamService;

        public HomeTeamController(IHomeTeamService hometeamService)
        {
            _hometeamService = hometeamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _hometeamService.GetAllHomeTeamsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _hometeamService.GetHomeTeamByIdAsync(id));
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
        public async Task<IActionResult> Post(HomeTeamCreate hometeam)
        {
            if(!ModelState.IsValid)return BadRequest(hometeam);
            if(await _hometeamService.CreateHomeTeamAsync(hometeam))
            return RedirectToAction(nameof(Index));
            else
            return View(hometeam);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var hometeam = await _hometeamService.GetHomeTeamByIdAsync(id);
            var hometeamEdit = new HomeTeamUpdate
            {
                Id = hometeam.Id,
                Name = hometeam.Name
            };
            return View(hometeamEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HomeTeamUpdate model)
        {
            if(id!=model.Id) return BadRequest("Invalid Id.");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _hometeamService.UpdateHomeTeamAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var hometeam = await _hometeamService.GetHomeTeamByIdAsync(id.Value);
            return View(hometeam);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _hometeamService.DeleteHomeTeamAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}