using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutFocuses
{
    public class WorkoutFocusPayloadBase : Payload
    {
        protected WorkoutFocusPayloadBase(WorkoutFocus workoutFocus)
        {
            WorkoutFocus = workoutFocus;
        }

        protected WorkoutFocusPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public WorkoutFocus? WorkoutFocus { get; }
    }
}
