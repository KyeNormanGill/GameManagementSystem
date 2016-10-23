using Microsoft.EntityFrameworkCore;
using MissionGameSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.Services
{
    public class ContestantApplicationService
    {
        private readonly MissionGameSystemDbContext _context;
        public ContestantApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Contestant> GetRoom(int? id)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == id);
            return contestant;
        }

        public async Task<Contestant> Create(string name, int age, string mood)
        {
            var contestant = new Contestant()
            {
                Name = name,
                Age = age,
                Mood = mood,
                GamesWon = 0
            };

            _context.Add(contestant);
            await _context.SaveChangesAsync();
            return contestant;
        }

        public async Task<Contestant> Edit(int id, string name, int age, string mood)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == id);
            contestant.Name = name;
            contestant.Age = age;
            contestant.Mood = mood;

            await _context.SaveChangesAsync();
            return contestant;
        }

        public async Task Delete(int id)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(r => r.Id == id);
            _context.Remove(contestant);
            await _context.SaveChangesAsync();
        }
    }
}
