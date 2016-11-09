﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGameSystem.UI.Models.ContestantViewModels
{
    public class ContestantDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mood { get; set; }
        public int GamesWon { get; set; }
    }
}
