using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.Extensions;
using HomeAPI.Schema.Operations.WorkoutDays;

namespace HomeAPI.Schema.Operations.Workouts
{
    [ExtendObjectType("Mutation")]
    public class WorkoutMutations
    {
        [UseApplicationDbContext]
        public async Task<AddWorkoutPayload> AddWorkoutAsync(
            AddWorkoutInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var workout = new Workout
            {
                ActualDay = input.ActualDay,
                ActualReps = input.ActualReps,
                ActualSets = input.ActualSets,
                ActualWeight = input.ActualWeight,
                Duration = input.Duration,
                WorkoutProgramId = input.WorkoutProgramId,
                ExerciseId = input.ExerciseId,
            };

            context.Workouts.Add(workout);
            await context.SaveChangesAsync(cancellationToken);

            return new AddWorkoutPayload(workout);
        }
    }
}
