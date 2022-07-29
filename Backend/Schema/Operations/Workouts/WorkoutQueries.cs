using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Operations.Workouts
{
    [ExtendObjectType("Query")]
    public class WorkoutQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Workout>> GetWorkoutsAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Workouts.ToListAsync(cancellationToken);

        public async Task<Workout> GetWorkoutByIdAsync(
            [ID(nameof(Workout))] Guid id,
            WorkoutByIdDataLoader workoutById,
            CancellationToken cancellationToken) =>
            await workoutById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Workout>> GetWorkoutsByIdAsync(
            [ID(nameof(Workout))] Guid[] ids,
            WorkoutByIdDataLoader workoutById,
            CancellationToken cancellationToken) =>
            await workoutById.LoadAsync(ids, cancellationToken);
    }
}
