import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminClientsListComponent } from './admin-clients-list.component';

describe('AdminClientsListComponent', () => {
  let component: AdminClientsListComponent;
  let fixture: ComponentFixture<AdminClientsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminClientsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminClientsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
