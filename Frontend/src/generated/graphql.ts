import { gql } from 'apollo-angular';
import { Injectable } from '@angular/core';
import * as Apollo from 'apollo-angular';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any;
  /** The built-in `Decimal` scalar type. */
  Decimal: any;
  UUID: any;
};

export type AddExerciseInput = {
  duration?: InputMaybe<Scalars['Decimal']>;
  name: Scalars['String'];
  preferredReps?: InputMaybe<Scalars['Int']>;
  preferredSets?: InputMaybe<Scalars['Int']>;
  preferredWeight?: InputMaybe<Scalars['Int']>;
};

export type AddExercisePayload = {
  __typename?: 'AddExercisePayload';
  exercise?: Maybe<Exercise>;
};

export type AddWorkoutDayInput = {
  day: Day;
  exerciseIds: Array<Scalars['UUID']>;
  workoutProgramId: Scalars['UUID'];
};

export type AddWorkoutDayPayload = {
  __typename?: 'AddWorkoutDayPayload';
  workoutDay?: Maybe<WorkoutDay>;
};

export type AddWorkoutFocusInput = {
  name: Scalars['String'];
};

export type AddWorkoutFocusPayload = {
  __typename?: 'AddWorkoutFocusPayload';
  workoutFocus?: Maybe<WorkoutFocus>;
};

export type AddWorkoutInput = {
  actualDay: Day;
  actualReps: Scalars['Int'];
  actualSets: Scalars['Int'];
  actualWeight: Scalars['Int'];
  duration?: InputMaybe<Scalars['Decimal']>;
  exerciseId: Scalars['UUID'];
  workoutProgramId: Scalars['UUID'];
};

export type AddWorkoutPayload = {
  __typename?: 'AddWorkoutPayload';
  workout?: Maybe<Workout>;
};

export type AddWorkoutProgramInput = {
  endDate?: InputMaybe<Scalars['DateTime']>;
  isActive: Scalars['Boolean'];
  name: Scalars['String'];
  startDate: Scalars['DateTime'];
  workoutFocusIds: Array<Scalars['UUID']>;
};

export type AddWorkoutProgramPayload = {
  __typename?: 'AddWorkoutProgramPayload';
  workoutProgram?: Maybe<WorkoutProgram>;
};

export enum Day {
  Friday = 'FRIDAY',
  Monday = 'MONDAY',
  Saturday = 'SATURDAY',
  Sunday = 'SUNDAY',
  Thursday = 'THURSDAY',
  Tuesday = 'TUESDAY',
  Wednesday = 'WEDNESDAY'
}

export type Exercise = {
  __typename?: 'Exercise';
  createdDate: Scalars['DateTime'];
  duration?: Maybe<Scalars['Decimal']>;
  id: Scalars['UUID'];
  name: Scalars['String'];
  preferredReps?: Maybe<Scalars['Int']>;
  preferredSets?: Maybe<Scalars['Int']>;
  preferredWeight?: Maybe<Scalars['Int']>;
  workoutDays: Array<WorkoutDay>;
};

export type Mutation = {
  __typename?: 'Mutation';
  addExercise: AddExercisePayload;
  addWorkout: AddWorkoutPayload;
  addWorkoutDay: AddWorkoutDayPayload;
  addWorkoutFocus: AddWorkoutFocusPayload;
  addWorkoutProgram: AddWorkoutProgramPayload;
};


export type MutationAddExerciseArgs = {
  input: AddExerciseInput;
};


export type MutationAddWorkoutArgs = {
  input: AddWorkoutInput;
};


export type MutationAddWorkoutDayArgs = {
  input: AddWorkoutDayInput;
};


export type MutationAddWorkoutFocusArgs = {
  input: AddWorkoutFocusInput;
};


export type MutationAddWorkoutProgramArgs = {
  input: AddWorkoutProgramInput;
};

export type Query = {
  __typename?: 'Query';
  exerciseById: Exercise;
  exercises: Array<Exercise>;
  exercisesById: Array<Exercise>;
  muscleFocusById: WorkoutFocus;
  muscleFocuses: Array<WorkoutFocus>;
  muscleFocusesById: Array<WorkoutFocus>;
  workoutById: Workout;
  workoutDayById: WorkoutDay;
  workoutDays: Array<WorkoutDay>;
  workoutDaysById: Array<WorkoutDay>;
  workoutProgramById: WorkoutProgram;
  workoutPrograms: Array<WorkoutProgram>;
  workoutProgramsById: Array<WorkoutProgram>;
  workouts: Array<Workout>;
  workoutsById: Array<Workout>;
};


export type QueryExerciseByIdArgs = {
  id: Scalars['ID'];
};


export type QueryExercisesByIdArgs = {
  ids: Array<Scalars['ID']>;
};


export type QueryMuscleFocusByIdArgs = {
  id: Scalars['ID'];
};


export type QueryMuscleFocusesByIdArgs = {
  ids: Array<Scalars['ID']>;
};


export type QueryWorkoutByIdArgs = {
  id: Scalars['ID'];
};


export type QueryWorkoutDayByIdArgs = {
  id: Scalars['ID'];
};


export type QueryWorkoutDaysByIdArgs = {
  ids: Array<Scalars['ID']>;
};


export type QueryWorkoutProgramByIdArgs = {
  id: Scalars['ID'];
};


export type QueryWorkoutProgramsByIdArgs = {
  ids: Array<Scalars['ID']>;
};


export type QueryWorkoutsByIdArgs = {
  ids: Array<Scalars['ID']>;
};

export type Workout = {
  __typename?: 'Workout';
  actualDay: Day;
  actualReps: Scalars['Int'];
  actualSets: Scalars['Int'];
  actualWeight: Scalars['Int'];
  createdDate: Scalars['DateTime'];
  duration?: Maybe<Scalars['Decimal']>;
  exercise?: Maybe<Exercise>;
  exerciseId?: Maybe<Scalars['ID']>;
  id: Scalars['UUID'];
  workoutProgram?: Maybe<WorkoutProgram>;
  workoutProgramId?: Maybe<Scalars['ID']>;
};

export type WorkoutDay = {
  __typename?: 'WorkoutDay';
  createdDate: Scalars['DateTime'];
  day: Day;
  exercises: Array<Exercise>;
  id: Scalars['UUID'];
  workoutProgram?: Maybe<WorkoutProgram>;
  workoutProgramId?: Maybe<Scalars['ID']>;
};

export type WorkoutFocus = {
  __typename?: 'WorkoutFocus';
  createdDate: Scalars['DateTime'];
  id: Scalars['UUID'];
  name: Scalars['String'];
  workoutPrograms: Array<WorkoutProgram>;
};

export type WorkoutProgram = {
  __typename?: 'WorkoutProgram';
  createdDate: Scalars['DateTime'];
  endDate?: Maybe<Scalars['DateTime']>;
  id: Scalars['UUID'];
  isActive: Scalars['Boolean'];
  name: Scalars['String'];
  startDate: Scalars['DateTime'];
  workoutDays: Array<WorkoutDay>;
  workoutFocuses: Array<WorkoutFocus>;
};

export type GetWorkoutProgramsQueryVariables = Exact<{ [key: string]: never; }>;


export type GetWorkoutProgramsQuery = { __typename?: 'Query', workoutPrograms: Array<{ __typename?: 'WorkoutProgram', id: any, name: string }> };

export type WorkoutProgramFragment = { __typename?: 'WorkoutProgram', id: any, name: string };

export const WorkoutProgramFragmentDoc = gql`
    fragment workoutProgram on WorkoutProgram {
  id
  name
}
    `;
export const GetWorkoutProgramsDocument = gql`
    query GetWorkoutPrograms {
  workoutPrograms {
    ...workoutProgram
  }
}
    ${WorkoutProgramFragmentDoc}`;

  @Injectable({
    providedIn: 'root'
  })
  export class GetWorkoutProgramsGQL extends Apollo.Query<GetWorkoutProgramsQuery, GetWorkoutProgramsQueryVariables> {
    override document = GetWorkoutProgramsDocument;
    
    constructor(apollo: Apollo.Apollo) {
      super(apollo);
    }
  }