﻿using System;
using GroupRun.Data.Enum;
using GroupRun.Models;

namespace GroupRun.ViewModels
{
	public class EditRaceViewModel
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string? URL { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public RaceCategory RaceCategory { get; set; }
    }
}

