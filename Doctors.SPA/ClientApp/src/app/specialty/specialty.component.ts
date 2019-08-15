import { Component, OnInit } from '@angular/core';
import { Specialty } from '../_models/models';
import { SpecialtyService } from '../_services/specialty.service';

@Component({
  selector: 'app-specialty',
  templateUrl: './specialty.component.html',
  styleUrls: ['./specialty.component.css']
})
export class SpecialtyComponent implements OnInit {
    specialty: Specialty = {}
    specialties: Specialty[]


  constructor(private specialtyService: SpecialtyService) { }

    ngOnInit() {
        this.getSpecialties();
  }


       getSpecialties() {
        this.specialtyService.getSpecialtys().subscribe((data: Specialty[]) => {
            //console.log(data);
            this.specialties = data;
        }, (error) => { console.log(error) });
    }

    addSpecialty() {
        this.specialtyService.addSpecialty(this.specialty).subscribe(data => {
            this.specialties.push(data)
            this.specialty = {}
        }, (error) => { console.log(error) })
    }

    clearMedicalSchool() {
        this.specialty = {}
    }


}
