import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Doctor } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'auth/';
    

    login(login: any) {
        return this.http.post<any>(this.basrurl + 'login', login);
    }

    addDoctor(register: any) {
        return this.http.post<any>(this.basrurl + 'register', register);
    }

}
