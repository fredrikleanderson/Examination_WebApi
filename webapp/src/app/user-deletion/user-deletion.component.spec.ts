import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDeletionComponent } from './user-deletion.component';

describe('UserDeletionComponent', () => {
  let component: UserDeletionComponent;
  let fixture: ComponentFixture<UserDeletionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserDeletionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDeletionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
