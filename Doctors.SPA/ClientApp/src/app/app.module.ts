import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DoctorListComponent } from './doctor/doctor-list/doctor-list.component';
import { DoctorDetailComponent } from './doctor/doctor-detail/doctor-detail.component';
import { appRoutes } from './app.routing';
import { DoctorService  } from './_services/doctor.service';
import { DoctorListResolvers } from './_resolvers/doctor-list.resolvers';
import { AveragePipe } from './_pipes/average.pipe';
import { RatingStatusPipe } from './_pipes/rating-status.pipe';
import { PatientRatingService } from './_services/patient-review.service';
import { LanguageService } from './_services/language.service';
import { MedicalSchoolService } from './_services/medical-school.service';
import { SpecialtyService } from './_services/specialty.service';
import { MedicalSchoolComponent } from './medical-school/medical-school.component';
import { SpecialtyComponent } from './specialty/specialty.component';
import { LanguageComponent } from './language/language.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
      HomeComponent,
    CounterComponent,
      FetchDataComponent,
      DoctorListComponent,
      DoctorDetailComponent,
      MedicalSchoolComponent,
      SpecialtyComponent,
      LanguageComponent,
      LoginComponent,
      RegisterComponent,
      AveragePipe,
      RatingStatusPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes)
  ],
    providers: [DoctorService,
        PatientRatingService,
        DoctorListResolvers,
        LanguageService,
        MedicalSchoolService,
        AuthService,
        SpecialtyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
