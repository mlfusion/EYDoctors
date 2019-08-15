import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Specialty } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class SpecialtyService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'specialty/';

    getSpecialtys() {
        return this.http.get<Specialty[]>(this.basrurl);
    }

    getSpecialty(id: number) {
        return this.http.get<Specialty>(this.basrurl + id);
    }

    addSpecialty(user: Specialty) {
        return this.http.post<Specialty>(this.basrurl, user);
    }


}
