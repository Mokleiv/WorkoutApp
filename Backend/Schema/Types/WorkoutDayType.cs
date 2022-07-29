using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Types
{
    public class WorkoutDayType : ObjectType<WorkoutDay>
    {
        protected override void Configure(IObjectTypeDescriptor<WorkoutDay> descriptor)
        {
            descriptor
                .Field(t => t.WorkoutDayExercises)
                .ResolveWith<WorkoutDayResolvers>(t => t.GetExercisesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("exercises");

            descriptor
                .Field(t => t.WorkoutProgram)
                .ResolveWith<WorkoutDayResolvers>(t => t.GetWorkoutProgramAsync(default!, default!, default));

            descriptor
                .Field(t => t.WorkoutProgramId)
                .ID(nameof(WorkoutProgram));
        }

        private class WorkoutDayResolvers
        {
            public async Task<IEnumerable<Exercise>> GetExercisesAsync(
                [Parent] WorkoutDay workoutDay,
                [ScopedService] ApplicationDbContext dbContext,
                ExerciseByIdDataLoader exerciseById,
                CancellationToken cancellationToken)
            {
                var exerciseIds = await dbContext.Exercises
                    .Where(s => s.Id.Equals(workoutDay.Id))
                    .Select(s => s.Id)
                    .ToArrayAsync(cancellationToken);

                return await exerciseById.LoadAsync(exerciseIds, cancellationToken);
            }

            public async Task<WorkoutProgram?> GetWorkoutProgramAsync(
                [Parent] WorkoutDay workoutDay,
                WorkoutProgramByIdDataLoader workoutProgramById,
                CancellationToken cancellationToken)
            {
                if (workoutDay.WorkoutProgramId is null)
                {
                    return null;
                }

                return await workoutProgramById.LoadAsync(workoutDay.WorkoutProgramId.Value, cancellationToken);
            }
        }
    }
}
