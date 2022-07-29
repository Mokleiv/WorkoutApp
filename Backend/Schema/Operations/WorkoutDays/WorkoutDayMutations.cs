using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.Extensions;
using HomeAPI.Schema.Operations.Exercises;

namespace HomeAPI.Schema.Operations.WorkoutDays
{
    [ExtendObjectType("Mutation")]
    public class WorkoutDayMutations
    {
        [UseApplicationDbContext]
        public async Task<AddWorkoutDayPayload> AddWorkoutDayAsync(
            AddWorkoutDayInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var workoutDay = new WorkoutDay
            {
                Day = input.Day,
                WorkoutProgramId = input.WorkoutProgramId,
            };

            foreach (var exerciseId in input.ExerciseIds)
            {
                workoutDay.WorkoutDayExercises.Add(new WorkoutDayExercise
                {
                    ExerciseId = exerciseId
                });
            }

            context.WorkoutDays.Add(workoutDay);
            await context.SaveChangesAsync(cancellationToken);

            return new AddWorkoutDayPayload(workoutDay);
        }
    }
}