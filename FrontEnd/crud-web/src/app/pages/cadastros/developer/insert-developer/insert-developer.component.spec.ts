import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertDeveloperComponent } from './insert-developer.component';

describe('InsertDeveloperComponent', () => {
  let component: InsertDeveloperComponent;
  let fixture: ComponentFixture<InsertDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsertDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
