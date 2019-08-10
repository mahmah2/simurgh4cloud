import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { RecaptchaModule } from 'ng-recaptcha';
// import { RecaptchaFormsModule } from 'ng-recaptcha/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { NoopAnimationsModule } from '@angular/platform-browser/animations';
//import { MatButtonModule, MatCheckboxModule } from '@angular/material';
//import { MatInputModule } from '@angular/material/input';
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


import { ContactService } from './service/contact-service/contact.service';
import { SubscriptionService } from './service/subscription-service/subscription.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FooterComponent } from './footer/footer.component';
import { Project1Component } from './project1/project1.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { DonationComponent } from './donation/donation.component';
import { ModalPictureComponent } from './modal-picture/modal-picture.component';
import { SafePipe } from './safe-pipe/safe.pipe';
import { PictureGalleryComponent } from './picture-gallery/picture-gallery.component';
import { ProjectProgressComponent } from './project-progress/project-progress.component';
import { SubscribeComponent } from './subscribe/subscribe.component';
import { ModalSubscriptionComponent } from './modal-subscription/modal-subscription.component';
import { SnackBarTemplateComponent } from './snack-bar-template/snack-bar-template.component';
import { AdminModuleModule } from './admin/admin-module.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PartnerListComponent } from './partner-list/partner-list.component';
import { Project2Component } from './project2/project2.component';
import { Project3Component } from './project3/project3.component';
import { ThankyouComponent } from './thankyou/thankyou.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    Project1Component,
    ProjectListComponent,
    AboutUsComponent,
    ContactUsComponent,
    StatisticsComponent,
    DonationComponent,
    ModalPictureComponent,
    SafePipe,
    PictureGalleryComponent,
    ProjectProgressComponent,
    SubscribeComponent,
    ModalSubscriptionComponent,
    SnackBarTemplateComponent,
    PageNotFoundComponent,
    PartnerListComponent,
    Project2Component,
    Project3Component,
    ThankyouComponent,
   
  ],
  entryComponents: [
    ModalPictureComponent,
    ModalSubscriptionComponent,
    SnackBarTemplateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RecaptchaModule,
    // RecaptchaFormsModule, // if you need forms support

    FormsModule,
    BrowserAnimationsModule,
    //NoopAnimationsModule,
    MatCardModule,
    MatInputModule,
    MatDialogModule,
    MatExpansionModule,
    MatGridListModule,
    MatSnackBarModule,

    //AdminModuleModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'project1', component: Project1Component },
      { path: 'project2', component: Project2Component },
      { path: 'project3', component: Project3Component },
      { path: 'project-list', component: ProjectListComponent },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'contact-us', component: ContactUsComponent },
      { path: 'partners', component: PartnerListComponent },
      { path: 'thankyou', component: ThankyouComponent },
      { path: '**', component: PageNotFoundComponent },
    ]),

  ],
  providers: [ContactService,
              SubscriptionService,
              ],
  bootstrap: [AppComponent]
})
export class AppModule { }
