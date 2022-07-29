using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.Exercises
{
    public class AddExercisePayload : Payload
    {
        public AddExercisePayload(Exercise exercise)
        {
            Exercise = exercise;
        }

        public AddExercisePayload(UserError error)
            : base(new[] { error })
        {
        }

        public Exercise? Exercise { get; init; }
    }
}
