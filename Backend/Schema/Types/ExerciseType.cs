using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Types
{
    public class ExerciseType : ObjectType<Exercise>
    {
        protected override void Configure(IObjectTypeDescriptor<Exercise> descriptor)
        {
            descriptor
                .Field(t => t.WorkoutDayExercises)
                .ResolveWith<ExerciseResolvers>(t => t.GetWorkoutDaysAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("workoutDays");
        }

        private class ExerciseResolvers
        {
            public async Task<IEnumerable<WorkoutDay>> GetWorkoutDaysAsync(
                [Parent] Exercise exercise,
                [ScopedService] ApplicationDbContext dbContext,
                WorkoutDayByIdDataLoader workoutDayById,
                CancellationToken cancellationToken)
            {
                var exerciseIds = await dbContext.Exercises
                    .Where(s => s.Id.Equals(exercise.Id))
                    .Include(s => s.WorkoutDayExercises)
                    .SelectMany(s => s.WorkoutDayExercises.Select(t => t.WorkoutDayId))
                    .ToArrayAsync(cancellationToken);

                return await workoutDayById.LoadAsync(exerciseIds, cancellationToken);
            }
        }
    }
}
