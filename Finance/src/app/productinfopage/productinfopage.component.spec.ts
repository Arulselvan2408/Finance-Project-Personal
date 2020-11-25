import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductinfopageComponent } from './productinfopage.component';

describe('ProductinfopageComponent', () => {
  let component: ProductinfopageComponent;
  let fixture: ComponentFixture<ProductinfopageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductinfopageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductinfopageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
