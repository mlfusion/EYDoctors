import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { DoctorListComponent } from "./doctor/doctor-list/doctor-list.component";
import { DoctorListResolvers } from './_resolvers/doctor-list.resolvers';
import { DoctorDetailComponent } from './doctor/doctor-detail/doctor-detail.component';
import { LanguageComponent } from './language/language.component';
import { MedicalSchoolComponent } from './medical-school/medical-school.component';
import { SpecialtyComponent } from './specialty/specialty.component';


export const appRoutes: Routes = [
   { path: '', component: HomeComponent, pathMatch: 'full' },
   { path: 'counter', component: CounterComponent },
   { path: 'fetch-data', component: FetchDataComponent },
   { path: 'doctor-list', component: DoctorListComponent, resolve: { doctors: DoctorListResolvers } },
    { path: 'doctor-detail/:id', component: DoctorDetailComponent },
    { path: 'language', component: LanguageComponent },
    { path: 'medical-school', component: MedicalSchoolComponent },
    { path: 'specialty', component: SpecialtyComponent },
   { path: '**', redirectTo: '', pathMatch: 'full' }
];
