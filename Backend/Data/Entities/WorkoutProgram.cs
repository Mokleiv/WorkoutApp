using HomeAPI.Common.Interface;

namespace HomeAPI.Data.Entities
{
    public class WorkoutProgram : IEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; } =
            new List<WorkoutDay>();
        public ICollection<WorkoutProgramFocus> WorkoutProgramFocuses { get; set; } =
            new List<WorkoutProgramFocus>();
    }
}
