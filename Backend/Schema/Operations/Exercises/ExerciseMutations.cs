using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.Extensions;
using HomeAPI.Schema.Operations.WorkoutPrograms;

namespace HomeAPI.Schema.Operations.Exercises
{
    [ExtendObjectType("Mutation")]
    public class ExerciseMutations
    {
        [UseApplicationDbContext]
        public async Task<AddExercisePayload> AddExerciseAsync(
            AddExerciseInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var exercise = new Exercise
            {
                Name = input.Name,
                PreferredReps = input.PreferredReps,
                PreferredSets = input.PreferredSets,
                PreferredWeight = input.PreferredWeight,
                Duration = input.Duration,
            };

            context.Exercises.Add(exercise);
            await context.SaveChangesAsync(cancellationToken);

            return new AddExercisePayload(exercise);
        }
    }
}
