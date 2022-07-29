using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAPI.DataLoader
{
    public class WorkoutFocusByIdDataLoader : BatchDataLoader<Guid, WorkoutFocus>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public WorkoutFocusByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, WorkoutFocus>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.WorkoutFocuses
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
