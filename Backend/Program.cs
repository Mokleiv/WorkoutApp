using HomeAPI.Data.ApplicationDbContext;
using HomeAPI.DataLoader;
using HomeAPI.Schema.Operations.Exercises;
using HomeAPI.Schema.Operations.WorkoutDays;
using HomeAPI.Schema.Operations.WorkoutFocuses;
using HomeAPI.Schema.Operations.WorkoutPrograms;
using HomeAPI.Schema.Operations.Workouts;
using HomeAPI.Schema.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(
    options => options.UseSqlite("Data Source=home.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<WorkoutProgramQueries>()
    .AddTypeExtension<WorkoutDayQueries>()
    .AddTypeExtension<ExerciseQueries>()
    .AddTypeExtension<WorkoutFocusQueries>()
    .AddTypeExtension<WorkoutQueries>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<WorkoutProgramMutations>()
    .AddTypeExtension<WorkoutDayMutations>()
    .AddTypeExtension<ExerciseMutations>()
    .AddTypeExtension<WorkoutFocusMutations>()
    .AddTypeExtension<WorkoutMutations>()
    .AddType<ExerciseType>()
    .AddType<WorkoutFocusType>()
    .AddType<WorkoutDayType>()
    .AddType<WorkoutProgramType>()
    .AddType<WorkoutType>()
    .AddDataLoader<ExerciseByIdDataLoader>()
    .AddDataLoader<WorkoutFocusByIdDataLoader>()
    .AddDataLoader<WorkoutDayByIdDataLoader>()
    .AddDataLoader<WorkoutProgramByIdDataLoader>()
    .AddDataLoader<WorkoutByIdDataLoader>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
