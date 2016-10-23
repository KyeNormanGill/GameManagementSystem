using Microsoft.EntityFrameworkCore;
using MissionGameSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.Services
{
    public class MissionApplicationService
    {
        private readonly MissionGameSystemDbContext _context;
        public MissionApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Mission> GetMission(int? id)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.Id == id);
            return mission;
        }

        public async Task<Mission> Create(string description, string note, int rewardPoints)
        {
            var mission = new Mission()
            {
                Description = description,
                Note = note,
                RewardPoints = rewardPoints
            };

            _context.Add(mission);
            await _context.SaveChangesAsync();
            return mission;
        }

        //Missions cannot be edited/updated
        //Must be delted and re-added

        public async Task Delete(int id)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.Id == id);
            _context.Remove(mission);
            await _context.SaveChangesAsync();
        }
    }
}
