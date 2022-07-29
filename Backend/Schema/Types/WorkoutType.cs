using HomeAPI.Data.Entities;
using HomeAPI.DataLoader;

namespace HomeAPI.Schema.Types
{
    public class WorkoutType : ObjectType<Workout>
    {
        protected override void Configure(IObjectTypeDescriptor<Workout> descriptor)
        {
            descriptor
                .Field(t => t.WorkoutProgram)
                .ResolveWith<WorkoutResolvers>(t => t.GetWorkoutProgramAsync(default!, default!, default));

            descriptor
                .Field(t => t.WorkoutProgramId)
                .ID(nameof(WorkoutProgram));

            descriptor
                .Field(t => t.Exercise)
                .ResolveWith<WorkoutResolvers>(t => t.GetExerciseAsync(default!, default!, default));

            descriptor
                .Field(t => t.ExerciseId)
                .ID(nameof(Exercise));
        }

        private class WorkoutResolvers
        {
            public async Task<WorkoutProgram?> GetWorkoutProgramAsync(
                [Parent] Workout workout,
                WorkoutProgramByIdDataLoader workoutProgramById,
                CancellationToken cancellationToken)
            {
                if (workout.WorkoutProgramId is null)
                {
                    return null;
                }

                return await workoutProgramById.LoadAsync(workout.WorkoutProgramId.Value, cancellationToken);
            }

            public async Task<Exercise?> GetExerciseAsync(
                [Parent] Workout workout,
                ExerciseByIdDataLoader exerciseById,
                CancellationToken cancellationToken)
            {
                if (workout.ExerciseId is null)
                {
                    return null;
                }

                return await exerciseById.LoadAsync(workout.ExerciseId.Value, cancellationToken);
            }
        }
    }
}