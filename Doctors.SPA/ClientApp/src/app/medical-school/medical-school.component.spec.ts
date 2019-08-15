import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalSchoolComponent } from './medical-school.component';

describe('MedicalSchoolComponent', () => {
  let component: MedicalSchoolComponent;
  let fixture: ComponentFixture<MedicalSchoolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedicalSchoolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicalSchoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
