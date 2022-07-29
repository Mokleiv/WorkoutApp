using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutFocuses
{
    public class AddWorkoutFocusPayload : Payload
    {
        public AddWorkoutFocusPayload(WorkoutFocus workoutFocus)
        {
            WorkoutFocus = workoutFocus;
        }

        public AddWorkoutFocusPayload(UserError error)
            : base(new[] { error })
        {
        }

        public WorkoutFocus? WorkoutFocus { get; init; }
    }
}
