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
        public IActionResult Index()
        {
            var contestants = _context.Contestants.Select(c => new ContestantIndexViewModel()
            {
                Id = c.Id,
                FirstName = c.Firstname,
                LastName = c.Lastname,
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
            var model = new ContestantDetailsViewModel()
            {
                FirstName = contestant.Firstname,
                LastName = contestant.Lastname,
                Address = contestant.Address,
                PhoneNumber = contestant.PhoneNumber,
                DateOfBirth = contestant.DateOfBirth,
                Mood = contestant.Mood,
                GamesWon = contestant.GamesWon
            };
            return View(model);
        }

        // GET: Contestant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contestant/Create
        [HttpPost]
        public async Task<IActionResult> Create(ContestantCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _contestantService.Create(model.Firstname, model.Lastname, model.Address, model.PhoneNumber, model.DateOfBirth, model.Mood);
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
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Mood = c.Mood
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
                await _contestantService.Edit(id,model.Address, model.PhoneNumber, model.Mood);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contestant/Delete/5
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _context.Contestants.Where(c => c.Id == id).Select(contestant => new ContestantDeleteViewModel()
            {
                Name = contestant.Firstname + " " + contestant.Lastname
            }).FirstOrDefault();
            return View(model);
        }

        // POST: Contestant/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == id);
            await _contestantService.Delete(contestant.Id);
            return RedirectToAction("Index");
        }
    }
}