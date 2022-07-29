using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Operations.Exercises
{
    [ExtendObjectType("Query")]
    public class ExerciseQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Exercise>> GetExercisesAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Exercises.ToListAsync(cancellationToken);

        public async Task<Exercise> GetExerciseByIdAsync(
            [ID(nameof(Exercise))] Guid id,
            ExerciseByIdDataLoader exerciseById,
            CancellationToken cancellationToken) =>
            await exerciseById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Exercise>> GetExercisesByIdAsync(
            [ID(nameof(Exercise))] Guid[] ids,
            ExerciseByIdDataLoader exerciseById,
            CancellationToken cancellationToken) =>
            await exerciseById.LoadAsync(ids, cancellationToken);
    }
}
