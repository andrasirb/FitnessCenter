using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessCenter.Models;

namespace FitnessCenter.Data
{
    public class FitnessCenterContext : DbContext
    {
        public FitnessCenterContext (DbContextOptions<FitnessCenterContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessCenter.Models.Member> Member { get; set; } = default!;
        public DbSet<FitnessCenter.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<FitnessCenter.Models.Workout> Workout { get; set; } = default!;
        public DbSet<FitnessCenter.Models.Reservation> Reservation { get; set; } = default!;


    }
}
