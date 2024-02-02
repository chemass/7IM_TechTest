import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Person } from './Person';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public searchResults: Person[] = [];
  public searchTerm: string = "";
  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

  doSearch(value: string) {
    this.http.get<Person[]>('/search/' + value).subscribe(
      (result: Person[]) => {
        this.searchResults = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = '7IM Tech Test - Angular Front End';
}
