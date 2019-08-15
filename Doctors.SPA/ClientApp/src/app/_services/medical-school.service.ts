import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MedicalSchool } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class MedicalSchoolService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'medicalSchool/';

    getMedicalSchools() {
        return this.http.get<MedicalSchool[]>(this.basrurl);
    }

    getMedicalSchool(id: number) {
        return this.http.get<MedicalSchool>(this.basrurl + id);
    }

    addMedicalSchool(medialSchool: MedicalSchool) {
        return this.http.post<MedicalSchool>(this.basrurl, medialSchool);
    }


}
