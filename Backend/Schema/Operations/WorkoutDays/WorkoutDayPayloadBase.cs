using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutDays
{
    public class WorkoutDayPayloadBase : Payload
    {
        protected WorkoutDayPayloadBase(WorkoutDay workoutDay)
        {
            WorkoutDay = workoutDay;
        }

        protected WorkoutDayPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public WorkoutDay? WorkoutDay { get; }
    }
}
