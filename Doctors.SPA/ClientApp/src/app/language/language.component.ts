import { Component, OnInit } from '@angular/core';
import { Language } from '../_models/models';
import { LanguageService } from '../_services/language.service';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {
    language: Language = {}
    languages: Language[]


  constructor(private languageService: LanguageService) { }

    ngOnInit() {
        this.getLanguages();
  }

    getLanguages() {
        this.languageService.getLanguages().subscribe((data: Language[]) => {
            this.languages = data;
        }, (error) => { console.log(error)})
    }


        addLanguage() {
        this.languageService.addLanguage(this.language).subscribe(data => {
            this.languages.push(data)
            this.language = {}
        }, (error) => { console.log(error) })
        }

    clearLanguage() {
        this.language = {}
    }


}
