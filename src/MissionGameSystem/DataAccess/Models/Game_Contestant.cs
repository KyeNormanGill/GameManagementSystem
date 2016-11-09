using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class Game_Contestant
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int ContestandId { get; set; }
        public Contestant Contestant { get; set; }
        public Game Game { get; set; }
    }
}
