import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorKorisnikChartComponent } from './administrator-korisnik-chart.component';

describe('AdministratorKorisnikChartComponent', () => {
  let component: AdministratorKorisnikChartComponent;
  let fixture: ComponentFixture<AdministratorKorisnikChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdministratorKorisnikChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdministratorKorisnikChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
