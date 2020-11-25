import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerregisterComponent } from './consumerregister.component';

describe('ConsumerregisterComponent', () => {
  let component: ConsumerregisterComponent;
  let fixture: ComponentFixture<ConsumerregisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsumerregisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerregisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
