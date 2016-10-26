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
        //Assign DbContext to constructor context for dependancy injection.
        public ContestantApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        //Create an object of Contestant from the database that has the same Id as the given Id.
        public async Task<Contestant> GetContestant(int? id)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == id);
            return contestant;
        }

        //Create a new Contestant object and assign the parameters with the one parsed in the method. save it, and return it.
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

        //Create a new Contestant object from the database with the same Id given, assign the new parameters from the method, save it, and return it.
        public async Task<Contestant> Edit(int id, string name, string mood)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(c => c.Id == id);
            contestant.Name = name;
            contestant.Mood = mood;

            await _context.SaveChangesAsync();
            return contestant;
        }

        //Create a new Contestant object from the database with the same Id given, remove it, and save it.
        public async Task Delete(int id)
        {
            var contestant = await _context.Contestants.FirstOrDefaultAsync(r => r.Id == id);
            _context.Remove(contestant);
            await _context.SaveChangesAsync();
        }
    }
}
