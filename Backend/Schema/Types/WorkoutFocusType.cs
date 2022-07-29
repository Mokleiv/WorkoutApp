using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Types
{
    public class WorkoutFocusType : ObjectType<WorkoutFocus>
    {
        protected override void Configure(IObjectTypeDescriptor<WorkoutFocus> descriptor)
        {
            descriptor
                .Field(t => t.WorkoutProgramFocuses)
                .ResolveWith<WorkoutFocusResolvers>(t => t.GetWorkoutProgramAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("workoutPrograms");
        }

        private class WorkoutFocusResolvers
        {
            public async Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramAsync(
                [Parent] WorkoutFocus workoutFocus,
                [ScopedService] ApplicationDbContext dbContext,
                WorkoutProgramByIdDataLoader workoutProgramById,
                CancellationToken cancellationToken)
            {
                var workoutProgramIds = await dbContext.WorkoutFocuses
                    .Where(s => s.Id.Equals(workoutFocus.Id))
                    .Include(s => s.WorkoutProgramFocuses)
                    .SelectMany(s => s.WorkoutProgramFocuses.Select(t => t.WorkoutProgramId))
                    .ToArrayAsync(cancellationToken);

                return await workoutProgramById.LoadAsync(workoutProgramIds, cancellationToken);
            }
        }
    }
}
