using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessCenter.Data;
using FitnessCenter.Models;

namespace FitnessCenter.Pages.Reservations
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
        ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "MemberId");
        ViewData["WorkoutId"] = new SelectList(_context.Workout, "WorkoutId", "WorkoutId");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
