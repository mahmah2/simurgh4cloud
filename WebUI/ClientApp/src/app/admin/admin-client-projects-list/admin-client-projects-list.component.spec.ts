import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminClientProjectsListComponent } from './admin-client-projects-list.component';

describe('AdminClientProjectsListComponent', () => {
  let component: AdminClientProjectsListComponent;
  let fixture: ComponentFixture<AdminClientProjectsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminClientProjectsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminClientProjectsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
