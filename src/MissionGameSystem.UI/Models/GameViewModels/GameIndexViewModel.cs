using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.UI.Models.GameViewModels
{
    public class GameIndexViewModel
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public bool Active { get; set; }
        public string Contestant { get; set; }
        public string Mission { get; set; }
        public string Prize { get; set; }
    }
}
