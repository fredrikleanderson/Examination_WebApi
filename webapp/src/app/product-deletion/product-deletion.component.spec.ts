import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDeletionComponent } from './product-deletion.component';

describe('ProductDeletionComponent', () => {
  let component: ProductDeletionComponent;
  let fixture: ComponentFixture<ProductDeletionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDeletionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDeletionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
