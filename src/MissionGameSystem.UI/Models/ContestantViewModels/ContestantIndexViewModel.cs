﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.UI.Models.ContestantViewModels
{
    public class ContestantIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mood { get; set; }
        public int GamesWon { get; set; }
    }
}
