using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.Exercises
{
    public class ExercisePayloadBase : Payload
    {
        protected ExercisePayloadBase(Exercise exercise)
        {
            Exercise = exercise;
        }

        protected ExercisePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Exercise? Exercise { get; }
    }
}
