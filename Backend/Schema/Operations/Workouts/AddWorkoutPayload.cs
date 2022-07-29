using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.Workouts
{
    public class AddWorkoutPayload : Payload
    {
        public AddWorkoutPayload(Workout workout)
        {
            Workout = workout;
        }

        public AddWorkoutPayload(UserError error)
            : base(new[] { error })
        {
        }

        public Workout? Workout { get; init; }
    }
}
