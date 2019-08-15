import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Doctor, Language } from '../_models/models';
import { DoctorService } from '../_services/doctor.service';
import { LanguageService } from '../_services/language.service';


@Injectable()
export class LanguageListResolvers implements Resolve<Language[]> {

    constructor(private languageService: LanguageService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Language[]> {
        return this.languageService.getLanguages().pipe(
            catchError(error => {
                console.log(error);
                return of(null);
            })
        );
    }
}
