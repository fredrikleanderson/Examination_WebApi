import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAdministrationComponent } from './product-administration.component';

describe('ProductAdministrationComponent', () => {
  let component: ProductAdministrationComponent;
  let fixture: ComponentFixture<ProductAdministrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductAdministrationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductAdministrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
