using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessCenter.Data;
using FitnessCenter.Models;

namespace FitnessCenter.Pages.Workouts
{
    public class CreateModel : PageModel
    {
        private readonly FitnessCenter.Data.FitnessCenterContext _context;

        public CreateModel(FitnessCenter.Data.FitnessCenterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "Name");
            return Page();
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Încearcă să afișezi erorile pentru a le vedea
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            _context.Workout.Add(Workout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
