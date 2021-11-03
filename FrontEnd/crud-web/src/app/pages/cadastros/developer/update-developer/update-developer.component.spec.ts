import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDeveloperComponent } from './update-developer.component';

describe('UpdateDeveloperComponent', () => {
  let component: UpdateDeveloperComponent;
  let fixture: ComponentFixture<UpdateDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
