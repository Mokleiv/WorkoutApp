using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Operations.WorkoutPrograms
{
    [ExtendObjectType("Query")]
    public class WorkoutProgramQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.WorkoutPrograms.ToListAsync(cancellationToken);

        public async Task<WorkoutProgram> GetWorkoutProgramByIdAsync(
            [ID(nameof(WorkoutProgram))] Guid id,
            WorkoutProgramByIdDataLoader workoutProgramById,
            CancellationToken cancellationToken) =>
            await workoutProgramById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsByIdAsync(
            [ID(nameof(WorkoutProgram))] Guid[] ids,
            WorkoutProgramByIdDataLoader workoutProgramById,
            CancellationToken cancellationToken) =>
            await workoutProgramById.LoadAsync(ids, cancellationToken);
    }
}
