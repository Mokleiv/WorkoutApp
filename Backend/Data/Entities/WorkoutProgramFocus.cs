namespace HomeAPI.Data.Entities
{
    public class WorkoutProgramFocus
    {
        public Guid WorkoutProgramId { get; set; }
        public WorkoutProgram? WorkoutProgram { get; set; }
        public Guid WorkoutFocusId { get; set; }
        public WorkoutFocus? WorkoutFocus { get; set; }
    }
}
