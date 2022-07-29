using HomeAPI.Common.Enum;
using HomeAPI.Common.Interface;

namespace HomeAPI.Data.Entities
{
    public class Workout : IEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public Day ActualDay { get; set; }
        public int ActualSets { get; set; }
        public int ActualReps { get; set; }
        public int ActualWeight { get; set; }
        public decimal? Duration { get; set; }
        public Guid? WorkoutProgramId { get; set; }
        public WorkoutProgram? WorkoutProgram { get; set; }
        public Guid? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
