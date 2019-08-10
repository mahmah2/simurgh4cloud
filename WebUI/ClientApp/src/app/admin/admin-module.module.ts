import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
} from '@angular/material';

import { AdminDashboardComponent } from '../admin/admin-dashboard/admin-dashboard.component';
import { AdminClientsListComponent } from '../admin/admin-clients-list/admin-clients-list.component';
import { AdminClientDetailComponent } from '../admin/admin-client-detail/admin-client-detail.component';
import { AdminClientProjectsListComponent } from '../admin/admin-client-projects-list/admin-client-projects-list.component';

import { ClientService } from '../service/client-service/client-service.service';
import { FileSystemService } from '../service/file-system-service/file-system.service';
import { ProjectService } from '../service/project-service/project.service';
import { AdminProjectDetailComponent } from '../admin/admin-project-detail/admin-project-detail.component';

const adminRoutes: Routes = [
  { path: 'admin', component: AdminDashboardComponent,
    //children: [
    //  { path: 'clients', component: AdminClientsListComponent, pathMatch:'full' },
    //  { path: '**', component: AdminDashboardComponent },
    //]
  },
  { path: 'admin/clients', component: AdminClientsListComponent },
  { path: 'admin/client/:id', component: AdminClientDetailComponent },
  { path: 'admin/client-projects/:id', component: AdminClientProjectsListComponent },
  { path: 'admin/project/:id', component: AdminProjectDetailComponent },
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatSnackBarModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    RouterModule.forChild(adminRoutes),
  ],
  exports: [
    RouterModule,
  ],
  declarations: [
    AdminDashboardComponent,
    AdminClientsListComponent,
    AdminClientDetailComponent,
    AdminClientProjectsListComponent,
    AdminProjectDetailComponent
  ],
  providers: [ClientService, FileSystemService, ProjectService]
})
export class AdminModuleModule { }
