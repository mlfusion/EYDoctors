import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Doctor } from '../_models/models';
import { DoctorService } from '../_services/doctor.service';


@Injectable()
export class DoctorListResolvers implements Resolve<Doctor[]> {

    constructor(private doctorService: DoctorService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Doctor[]> {
        return this.doctorService.getDoctors().pipe(
            catchError(error => {
                console.log(error);
                return of(null);
            })
        );
    }
}
