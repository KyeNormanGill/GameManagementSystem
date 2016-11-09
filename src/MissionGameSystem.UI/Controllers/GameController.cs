using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionGameSystem.DataAccess.Models;
using MissionGameSystem.Services;
using MissionGameSystem.UI.Models.GameViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MissionGameSystem.UI.Controllers
{
    public class GameController : Controller
    {
        private MissionGameSystemDbContext _context;
        private GameApplicationService _gameService;
        public GameController(MissionGameSystemDbContext context, GameApplicationService gameService)
        {
            _context = context;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var game = _context.Games.Where(g => g.Active == true).Select(g => new GameIndexViewModel()
            {
                Id = g.Id,
                Theme = g.Theme,
                SDate = g.StartDate,
                EDate = g.EndDate,
                Active = g.Active,
                Prize = g.Prize,
                Contestant = string.Join(", ", g.Game_Contestants.Select(gc => gc.Contestant.Firstname)),
                Mission = string.Join(", ", g.Game_Missions.Select(gm => gm.Mission.Description))
            }).FirstOrDefault();
            if(game == null)
            {
                return RedirectToAction("Create");
            }
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new GameCreateViewModel()
            {
                Contestants = new MultiSelectList(_context.Contestants.ToList(), "Id", "Name"),
                Missions = new MultiSelectList(_context.Missions.ToList(), "Id", "Description")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _gameService.Create(model.Theme, model.StartDate, model.EndDate, model.Prize, model.ContestantIds, model.MissionIds);
                return RedirectToAction("Index");
            }
            model.Contestants = new MultiSelectList(_context.Contestants.ToList(), "Id", "Name");
            model.Missions = new MultiSelectList(_context.Missions.ToList(), "Id", "Description");
            return View(model);
        }
    }
}
