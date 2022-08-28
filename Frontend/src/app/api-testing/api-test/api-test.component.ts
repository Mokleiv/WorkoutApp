import { Component, OnInit } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { firstValueFrom, map } from 'rxjs';
import { GetWorkoutProgramsGQL, WorkoutProgramFragment } from 'src/generated/graphql';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-api-test',
  templateUrl: './api-test.component.html',
  styleUrls: ['./api-test.component.scss'],
})
export class ApiTestComponent implements OnInit {
  workoutPrograms: WorkoutProgramFragment[] = [];

  subs = new SubSink();

  constructor(private getWorkoutPrograms: GetWorkoutProgramsGQL) {}
  // ! This is a comment
  async ngOnInit() {
    this.workoutPrograms = await firstValueFrom(
      this.getWorkoutPrograms.fetch().pipe(map((x) => x.data.workoutPrograms))
    );

    console.log(this.workoutPrograms);

    // this.apollo
    //   .watchQuery({
    //     query: gql`
    //       {
    //         workoutPrograms {
    //           id
    //           name
    //         }
    //       }
    //     `,
    //   })
    //   .valueChanges.subscribe((response) => {
    //     console.log(response);
    //   });
  }
}
