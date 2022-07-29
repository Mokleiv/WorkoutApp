using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Operations.WorkoutDays
{
    [ExtendObjectType("Query")]
    public class WorkoutDayQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<WorkoutDay>> GetWorkoutDaysAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.WorkoutDays.ToListAsync(cancellationToken);

        public async Task<WorkoutDay> GetWorkoutDayByIdAsync(
            [ID(nameof(WorkoutDay))] Guid id,
            WorkoutDayByIdDataLoader workoutDayById,
            CancellationToken cancellationToken) =>
            await workoutDayById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<WorkoutDay>> GetWorkoutDaysByIdAsync(
            [ID(nameof(WorkoutDay))] Guid[] ids,
            WorkoutDayByIdDataLoader workoutDayById,
            CancellationToken cancellationToken) =>
            await workoutDayById.LoadAsync(ids, cancellationToken);
    }
}
