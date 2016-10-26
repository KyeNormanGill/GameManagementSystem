using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MissionGameSystem.DataAccess.Models;
using MissionGameSystem.Services;
using MissionGameSystem.UI.Models.MissionViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MissionGameSystem.UI.Controllers
{
    public class MissionController : Controller
    {
        private MissionGameSystemDbContext _context;
        private MissionApplicationService _missionService;
        public MissionController(MissionGameSystemDbContext context, MissionApplicationService missionService)
        {
            _context = context;
            _missionService = missionService;
        }
        public IActionResult Index()
        {
            var missions = _context.Missions.Select(m => new MissionIndexViewModel()
            {
                Id = m.Id,
                Description = m.Description
            }).ToList();
            return View(missions);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var mission = await _missionService.GetMission(id);
            var model = new MissionDetailsViewModel()
            {
                Description = mission.Description,
                Note = mission.Note,
                RewardPoints = mission.RewardPoints
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MissionCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _missionService.Create(model.Description, model.Note, model.RewardPoints);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _context.Missions.Where(m => m.Id == id).Select(mission => new MissionDeleteViewModel()
            {
                Description = mission.Description
            }).FirstOrDefault();
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.Id == id);
            await _missionService.Delete(mission.Id);
            return RedirectToAction("Index");
        }
    }
}