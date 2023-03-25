import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddourseComponent } from './addourse.component';

describe('AddourseComponent', () => {
  let component: AddourseComponent;
  let fixture: ComponentFixture<AddourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddourseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
