import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalSubscriptionComponent } from './modal-subscription.component';

describe('ModalSubscriptionComponent', () => {
  let component: ModalSubscriptionComponent;
  let fixture: ComponentFixture<ModalSubscriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalSubscriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalSubscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
