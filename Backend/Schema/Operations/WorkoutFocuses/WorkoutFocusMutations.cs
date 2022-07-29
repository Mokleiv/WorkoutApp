using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.Extensions;
using HomeAPI.Schema.Operations.Exercises;

namespace HomeAPI.Schema.Operations.WorkoutFocuses
{
    [ExtendObjectType("Mutation")]
    public class WorkoutFocusMutations
    {
        [UseApplicationDbContext]
        public async Task<AddWorkoutFocusPayload> AddWorkoutFocusAsync(
            AddWorkoutFocusInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var muscleFocus = new WorkoutFocus
            {
                Name = input.Name,
            };

            context.WorkoutFocuses.Add(muscleFocus);
            await context.SaveChangesAsync(cancellationToken);

            return new AddWorkoutFocusPayload(muscleFocus);
        }
    }
}
