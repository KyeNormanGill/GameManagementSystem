using Microsoft.EntityFrameworkCore;
using MissionGameSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.Services
{
    public class GameApplicationService
    {
        private MissionGameSystemDbContext _context;
        public GameApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        public async Task Create(string theme, DateTime startTime, DateTime endDate, string prize, List<int> contestantIds, List<int> missionsIds)
        {
            var game = new Game()
            {
                Theme = theme,
                StartDate = startTime,
                EndDate = endDate,
                Prize = prize,
                Active = true
            };

            foreach (var contestantId in contestantIds)
            {
                var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == contestantId);
                game.Game_Contestants.Add(new Game_Contestant()
                {
                    Contestant = contestant
                });
            }

            foreach (var missionId in missionsIds)
            {
                var mission = await _context.Missions.FirstOrDefaultAsync(m => m.Id == missionId);
                game.Game_Missions.Add(new Game_Mission()
                {
                    Mission = mission
                });
            }
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            _context.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
