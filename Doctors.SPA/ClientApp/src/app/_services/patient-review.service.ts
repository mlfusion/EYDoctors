import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PatientRating } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class PatientRatingService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'patientrating/';

    getPatientRatings() {
        return this.http.get<PatientRating[]>(this.basrurl);
    }

    getPatientRating(id: number) {
        return this.http.get<PatientRating>(this.basrurl + id);
    }

    addPatientRating(rating: PatientRating) {
        return this.http.post<PatientRating>(this.basrurl, rating);
    }


}
