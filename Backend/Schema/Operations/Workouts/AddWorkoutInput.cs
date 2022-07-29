using HomeAPI.Common.Enum;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.Workouts
{
    public record AddWorkoutInput(
        Day ActualDay,
        int ActualSets,
        int ActualReps,
        int ActualWeight,
        decimal? Duration,
        [ID(nameof(WorkoutProgram))]
        Guid WorkoutProgramId,
        [ID(nameof(Exercise))]
        Guid ExerciseId);
}