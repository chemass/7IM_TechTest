import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { SearchBoxComponent } from './search-box/search-box.component';
import { PersonCardComponent } from './person-card/person-card.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule, SearchBoxComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve people from the server', () => {
    const mockPeople = [
      { id: 1, firstName: "Arthur", lastName: "Dent", email: "arthur.dent@whereismytowel.net", gender: "Male" },
      { id: 2, firstName: "Ford", lastName: "Prefect", email: "froody.dude@whereismytowel.net", gender: "Male" },
    ];

    component.doSearch("whereismytowel");

    const req = httpMock.expectOne('/search/whereismytowel');
    expect(req.request.method).toEqual('GET');
    req.flush(mockPeople);

    expect(component.searchResults).toEqual(mockPeople);
  });
});
