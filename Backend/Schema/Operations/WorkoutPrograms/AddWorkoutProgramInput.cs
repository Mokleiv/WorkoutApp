using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutPrograms
{
    public record AddWorkoutProgramInput(
        string Name,
        bool IsActive,
        DateTimeOffset StartDate,
        DateTimeOffset? EndDate,
        [ID(nameof(WorkoutFocus))]
        IReadOnlyList<Guid> WorkoutFocusIds);
}
