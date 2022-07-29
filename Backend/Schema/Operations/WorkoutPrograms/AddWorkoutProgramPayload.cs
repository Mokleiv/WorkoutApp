using HomeAPI.Common.Base;
using HomeAPI.Data.Entities;

namespace HomeAPI.Schema.Operations.WorkoutPrograms
{
    public class AddWorkoutProgramPayload : Payload
    {
        public AddWorkoutProgramPayload(WorkoutProgram workoutProgram)
        {
            WorkoutProgram = workoutProgram;
        }

        public AddWorkoutProgramPayload(UserError error)
            : base(new[] { error })
        {
        }

        public WorkoutProgram? WorkoutProgram { get; init; }
    }
}
