import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeveloperComponent } from './grid-developer.component';

describe('GridDeveloperComponent', () => {
  let component: GridDeveloperComponent;
  let fixture: ComponentFixture<GridDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GridDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GridDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
