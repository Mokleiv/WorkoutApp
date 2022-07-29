using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Types
{
    public class WorkoutProgramType : ObjectType<WorkoutProgram>
    {
        protected override void Configure(IObjectTypeDescriptor<WorkoutProgram> descriptor)
        {
            descriptor
                .Field(t => t.WorkoutProgramFocuses)
                .ResolveWith<WorkoutProgramResolvers>(t => t.GetWorkoutFocusesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("workoutFocuses");

            descriptor
                .Field(t => t.WorkoutDays)
                .ResolveWith<WorkoutProgramResolvers>(t => t.GetWorkoutDaysAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("workoutDays");
        }

        private class WorkoutProgramResolvers
        {
            public async Task<IEnumerable<WorkoutFocus>> GetWorkoutFocusesAsync(
                [Parent] WorkoutProgram workoutProgram,
                [ScopedService] ApplicationDbContext dbContext,
                WorkoutFocusByIdDataLoader workoutFocusById,
                CancellationToken cancellationToken)
            {
                var workoutFocusIds = await dbContext.WorkoutPrograms
                    .Where(s => s.Id.Equals(workoutProgram.Id))
                    .Include(s => s.WorkoutProgramFocuses)
                    .SelectMany(s => s.WorkoutProgramFocuses.Select(t => t.WorkoutFocusId))
                    .ToArrayAsync(cancellationToken);

                return await workoutFocusById.LoadAsync(workoutFocusIds, cancellationToken);
            }

            public async Task<IEnumerable<WorkoutDay>> GetWorkoutDaysAsync(
                [Parent] WorkoutProgram workoutProgram,
                [ScopedService] ApplicationDbContext dbContext,
                WorkoutDayByIdDataLoader workoutDayById,
                CancellationToken cancellationToken)
            {
                var workoutDayIds = await dbContext.WorkoutDays
                    .Where(s => s.Id.Equals(workoutProgram.Id))
                    .Select(s => s.Id)
                    .ToArrayAsync(cancellationToken);

                return await workoutDayById.LoadAsync(workoutDayIds, cancellationToken);
            }
        }
    }
}
