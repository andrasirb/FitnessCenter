using System;
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
    public class DetailsModel : PageModel
    {
        private readonly FitnessCenter.Data.FitnessCenterContext _context;

        public DetailsModel(FitnessCenter.Data.FitnessCenterContext context)
        {
            _context = context;
        }

        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout.FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (workout == null)
            {
                return NotFound();
            }
            else
            {
                Workout = workout;
            }
            return Page();
        }
    }
}
