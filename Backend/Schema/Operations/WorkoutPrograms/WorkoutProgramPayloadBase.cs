using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutPrograms
{
    public class WorkoutProgramPayloadBase : Payload
    {
        protected WorkoutProgramPayloadBase(WorkoutProgram workoutProgram)
        {
            WorkoutProgram = workoutProgram;
        }

        protected WorkoutProgramPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public WorkoutProgram? WorkoutProgram { get; }
    }
}
