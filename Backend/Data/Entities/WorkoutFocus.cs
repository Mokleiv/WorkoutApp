using HomeAPI.Common.Interface;

namespace HomeAPI.Data.Entities
{
    public class WorkoutFocus : IEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public string Name { get; set; }
        public ICollection<WorkoutProgramFocus> WorkoutProgramFocuses { get; set; } =
            new List<WorkoutProgramFocus>();
    }
}
