import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorProizvodiChartComponent } from './administrator-proizvodi-chart.component';

describe('AdministratorProizvodiChartComponent', () => {
  let component: AdministratorProizvodiChartComponent;
  let fixture: ComponentFixture<AdministratorProizvodiChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdministratorProizvodiChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdministratorProizvodiChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
