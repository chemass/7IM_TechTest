import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule]
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

    component.doSearch();

    const req = httpMock.expectOne('/search');
    expect(req.request.method).toEqual('POST');
    req.flush(mockPeople);

    expect(component.searchResults).toEqual(mockPeople);
  });
});
