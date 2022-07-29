using HomeAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many: WorkoutDay <-> Exercise
            modelBuilder
                .Entity<WorkoutDayExercise>()
                .HasKey(x => new { x.WorkoutDayId, x.ExerciseId });

            // Many-to-many: WorkoutProgram <-> WorkoutFocus
            modelBuilder
                .Entity<WorkoutProgramFocus>()
                .HasKey(x => new { x.WorkoutProgramId, x.WorkoutFocusId });
        }

        public DbSet<Exercise> Exercises { get; set; } = default!;
        public DbSet<WorkoutFocus> WorkoutFocuses { get; set; } = default!;
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; } = default!;
        public DbSet<WorkoutDay> WorkoutDays { get; set; } = default!;
        public DbSet<Workout> Workouts { get; set; } = default!;
    }
}
