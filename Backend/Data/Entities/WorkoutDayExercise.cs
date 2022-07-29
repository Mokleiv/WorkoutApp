namespace HomeAPI.Data.Entities
{
    public class WorkoutDayExercise
    {
        public Guid WorkoutDayId { get; set; }
        public WorkoutDay? WorkoutDay { get; set; }
        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
