namespace HomeAPI.Schema.Operations.Exercises
{
    public record AddExerciseInput(
        string Name,
        int? PreferredSets,
        int? PreferredReps,
        int? PreferredWeight,
        decimal? Duration);
}