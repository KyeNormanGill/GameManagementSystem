using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionGameSystem.DataAccess.Models;
using MissionGameSystem.Services;
using MissionGameSystem.UI.Models.ContestantViewModels;
using Microsoft.EntityFrameworkCore;

namespace MissionGameSystem.UI.Controllers
{
    public class ContestantController : Controller
    {
        private MissionGameSystemDbContext _context;
        private ContestantApplicationService _contestantService;
        public ContestantController(MissionGameSystemDbContext context, ContestantApplicationService contestantService)
        {
            _context = context;
            _contestantService = contestantService;
        }

        // GET: Contestant
        public ActionResult Index()
        {
            var contestants = _context.Contestants.Select(c => new ContestantIndexViewModel()
            {
                Name = c.Name,
                Age = c.Age,
                //Take out age
                Mood = c.Mood,
                //Take out mood
                GamesWon = c.GamesWon
            }).ToList();
            return View(contestants);
        }

        // GET: Contestant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contestant = await _contestantService.GetContestant(id);
            var model = new ContestantIndexViewModel()
            {
                Name = contestant.Name,
                Age = contestant.Age,
                Mood = contestant.Mood,
                //Take out mood
                GamesWon = contestant.GamesWon
            };
            return View();
        }

        // GET: Contestant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contestant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContestantCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _contestantService.Create(model.Name, model.Age, model.Mood);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contestant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Contestants.Where(c => c.Id == id).Select(c => new ContestantUpdateViewModel
            {
                Name = c.Name,
                Mood = c.Mood,
            }).FirstOrDefaultAsync();
            return View(model);
        }

        // POST: Contestant/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContestantUpdateViewModel model)
        {
            if(model == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                await _contestantService.Edit(id, model.Name, model.Mood);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contestant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contestant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}