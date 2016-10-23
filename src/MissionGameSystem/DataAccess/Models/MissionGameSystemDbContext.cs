using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class MissionGameSystemDbContext : DbContext
    {
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Prize> Prizes { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\mssqllocaldb;Initial Catalog=GameManagementSystemDb;Integrated Security=true;");
        }
    }
}
