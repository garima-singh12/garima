import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchChallenge {
  public forecasts: challenge[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<challenge[]>(baseUrl + 'Challenge').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface challenge {
  TodaysDate: string;

  Message: string;
}
