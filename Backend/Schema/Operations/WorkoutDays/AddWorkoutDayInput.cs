using HomeAPI.Common.Enum;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutDays
{
    public record AddWorkoutDayInput(
    Day Day,
    [ID(nameof(WorkoutProgram))]
    Guid WorkoutProgramId,
    [ID(nameof(Exercise))]
    IReadOnlyList<Guid> ExerciseIds);
}
