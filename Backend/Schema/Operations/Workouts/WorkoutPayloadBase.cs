using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.Workouts
{
    public class WorkoutPayloadBase : Payload
    {
        protected WorkoutPayloadBase(Workout workout)
        {
            Workout = workout;
        }

        protected WorkoutPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Workout? Workout { get; }
    }
}
