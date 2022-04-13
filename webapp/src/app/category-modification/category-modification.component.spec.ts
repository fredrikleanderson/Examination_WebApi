import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryModificationComponent } from './category-modification.component';

describe('CategoryModificationComponent', () => {
  let component: CategoryModificationComponent;
  let fixture: ComponentFixture<CategoryModificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryModificationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryModificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
