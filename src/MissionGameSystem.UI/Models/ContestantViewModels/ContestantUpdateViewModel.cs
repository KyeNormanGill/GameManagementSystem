﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.UI.Models.ContestantViewModels
{
    public class ContestantUpdateViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Mood { get; set; }
    }
}
