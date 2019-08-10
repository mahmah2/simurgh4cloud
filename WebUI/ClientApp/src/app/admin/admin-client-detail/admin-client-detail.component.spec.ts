import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminClientDetailComponent } from './admin-client-detail.component';

describe('AdminClientDetailComponent', () => {
  let component: AdminClientDetailComponent;
  let fixture: ComponentFixture<AdminClientDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminClientDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminClientDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
