using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;
using HomeAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Schema.Operations.WorkoutFocuses
{
    [ExtendObjectType("Query")]
    public class WorkoutFocusQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<WorkoutFocus>> GetMuscleFocusesAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.WorkoutFocuses.ToListAsync(cancellationToken);

        public async Task<WorkoutFocus> GetMuscleFocusByIdAsync(
            [ID(nameof(WorkoutFocus))] Guid id,
            WorkoutFocusByIdDataLoader muscleFocusById,
            CancellationToken cancellationToken) =>
            await muscleFocusById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<WorkoutFocus>> GetMuscleFocusesByIdAsync(
            [ID(nameof(WorkoutFocus))] Guid[] ids,
            WorkoutFocusByIdDataLoader muscleFocusById,
            CancellationToken cancellationToken) =>
            await muscleFocusById.LoadAsync(ids, cancellationToken);
    }
}
