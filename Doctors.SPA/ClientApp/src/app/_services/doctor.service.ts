import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Doctor } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class DoctorService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'doctors/';

    getDoctors() {
        return this.http.get<Doctor[]>(this.basrurl);
    }

    getDoctor(id: number) {
        return this.http.get<Doctor>(this.basrurl + id);
    }

    addDoctor(user: Doctor) {
        return this.http.post<Doctor>(this.basrurl, user);
    }


}
