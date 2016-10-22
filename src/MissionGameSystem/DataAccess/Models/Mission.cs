using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.DataAccess.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int RewardPoints { get; set; }
    }
}
