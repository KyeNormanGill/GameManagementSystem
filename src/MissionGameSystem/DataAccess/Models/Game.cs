using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        [Required]
        [Column(TypeName ="datetime2")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }
        [Required]
        public bool Active { get; set; }
        public string Prize { get; set; }
        public List<Game_Contestant> Game_Contestants { get; set; }
        public List<Game_Mission> Game_Missions { get; set; }

        public Game()
        {
            Game_Contestants = new List<Game_Contestant>();
            Game_Missions = new List<Game_Mission>();
        }
    }
}
