using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class Game_Mission
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int MissionId { get; set; }
        public Game Game { get; set; }
        public Mission Mission { get; set; }
    }
}
