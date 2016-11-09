using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.UI.Models.GameViewModels
{
    public class GameCreateViewModel
    {
        public string Theme { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        [Required]
        [Display(Name = "Contestants")]
        public List<int> ContestantIds { get; set; }
        public MultiSelectList Contestants { get; set; }
        [Required]
        [Display(Name = "Missions")]
        public List<int> MissionIds { get; set; }
        public MultiSelectList Missions { get; set; }
    }
}
