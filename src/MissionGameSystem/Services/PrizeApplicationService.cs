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
        public PrizeApplicationService(MissionGameSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Prize> GetPrize(int? id)
        {
            var prize = await _context.Prizes.FirstOrDefaultAsync(p => p.Id == id);
            return prize;
        }

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

        public async Task Delete(int id)
        {
            var prize = await _context.Prizes.FirstOrDefaultAsync(p => p.Id == id);
            _context.Remove(prize);
            await _context.SaveChangesAsync();
        }
    }
}
