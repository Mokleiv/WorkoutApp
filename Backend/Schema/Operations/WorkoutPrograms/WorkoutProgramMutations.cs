using HomeAPI.Common.Base;
using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.Extensions;

namespace HomeAPI.Schema.Operations.WorkoutPrograms
{
    [ExtendObjectType("Mutation")]
    public class WorkoutProgramMutations
    {
        [UseApplicationDbContext]
        public async Task<AddWorkoutProgramPayload> AddWorkoutProgramAsync(
            AddWorkoutProgramInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var workoutProgram = new WorkoutProgram
            {
                Name = input.Name,
                IsActive = input.IsActive,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
            };

            foreach (var workoutFocusId in input.WorkoutFocusIds)
            {
                workoutProgram.WorkoutProgramFocuses.Add(new WorkoutProgramFocus
                {
                    WorkoutFocusId = workoutFocusId
                });
            }

            context.WorkoutPrograms.Add(workoutProgram);
            await context.SaveChangesAsync(cancellationToken);

            return new AddWorkoutProgramPayload(workoutProgram);
        }
    }
}
