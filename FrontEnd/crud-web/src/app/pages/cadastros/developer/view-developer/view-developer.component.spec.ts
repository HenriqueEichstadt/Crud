import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDeveloperComponent } from './view-developer.component';

describe('ViewDeveloperComponent', () => {
  let component: ViewDeveloperComponent;
  let fixture: ComponentFixture<ViewDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
