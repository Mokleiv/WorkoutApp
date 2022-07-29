using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutDays
{
    public class AddWorkoutDayPayload : Payload
    {
        public AddWorkoutDayPayload(WorkoutDay workoutDay)
        {
            WorkoutDay = workoutDay;
        }

        public AddWorkoutDayPayload(UserError error)
            : base(new[] { error })
        {
        }

        public WorkoutDay? WorkoutDay { get; init; }
    }
}
