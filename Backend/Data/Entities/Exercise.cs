using HomeAPI.Common.Interface;

namespace HomeAPI.Data.Entities
{
    public class Exercise : IEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public string Name { get; set; }
        public int? PreferredSets { get; set; }
        public int? PreferredReps { get; set; }
        public int? PreferredWeight { get; set; }
        public decimal? Duration { get; set; }
        public ICollection<WorkoutDayExercise> WorkoutDayExercises { get; set; } =
            new List<WorkoutDayExercise>();
    }
}
