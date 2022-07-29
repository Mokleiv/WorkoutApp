using HomeAPI.Common.Enum;
using HomeAPI.Common.Interface;

namespace HomeAPI.Data.Entities
{
    public class WorkoutDay : IEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public Day Day { get; set; }
        public Guid? WorkoutProgramId { get; set; }
        public WorkoutProgram? WorkoutProgram { get; set; }
        public ICollection<WorkoutDayExercise> WorkoutDayExercises { get; set; } =
            new List<WorkoutDayExercise>();
    }
}
