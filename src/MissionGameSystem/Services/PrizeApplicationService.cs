using Microsoft.EntityFrameworkCore;
using MissionGameSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.Services
{
    public class PrizeApplicationService
    {
        private readonly MissionGameSystemDbContext _context;
        //Assign DbContext to constructor context for dependancy injection.
        public PrizeApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        //Create an object of Prize that has the same Id as the given Id.
        public async Task<Prize> GetPrize(int? id)
        {
            var prize = await _context.Prizes.FirstOrDefaultAsync(p => p.Id == id);
            return prize;
        }

        //Create a new object and assign the parameters with the ones parsed in the method, save it, and return it.
        public async Task<Prize> Create(string name, string worth)
        {
            var prize = new Prize()
            {
                Name = name,
                Worth = worth
            };

            _context.Add(prize);
            await _context.SaveChangesAsync();
            return prize;
        }

        //Create an object and grab the Prize with the same Id as given, remove it, and save changes.
        public async Task Delete(int id)
        {
            var prize = await _context.Prizes.FirstOrDefaultAsync(p => p.Id == id);
            _context.Remove(prize);
            await _context.SaveChangesAsync();
        }
    }
}
