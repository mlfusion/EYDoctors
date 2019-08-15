import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Language } from '../_models/models'

@Injectable({
    providedIn: 'root'
})
export class LanguageService {

    constructor(private http: HttpClient) { }
    basrurl = environment.apiUrl + 'language/';

    getLanguages() {
        return this.http.get<Language[]>(this.basrurl);
    }

    getLanguage(id: number) {
        return this.http.get<Language>(this.basrurl + id);
    }

    addLanguage(user: Language) {
        return this.http.post<Language>(this.basrurl, user);
    }


}
