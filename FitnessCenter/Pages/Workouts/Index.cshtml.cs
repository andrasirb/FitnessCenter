﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessCenter.Data;
using FitnessCenter.Models;

namespace FitnessCenter.Pages.Workouts
{
    public class IndexModel : PageModel
    {
        private readonly FitnessCenter.Data.FitnessCenterContext _context;

        public IndexModel(FitnessCenter.Data.FitnessCenterContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Workout = await _context.Workout
                .Include(w => w.Instructor).ToListAsync();
        }
    }
}
