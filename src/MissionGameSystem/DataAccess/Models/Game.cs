using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        //make linking table for missions
        //make linking table for contestants
        //make linking table for prize
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }
}
