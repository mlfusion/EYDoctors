import { Component, OnInit } from '@angular/core';
import { MedicalSchool } from '../_models/models';
import { MedicalSchoolService } from '../_services/medical-school.service';

@Component({
    selector: 'app-medical-school',
    templateUrl: './medical-school.component.html',
    styleUrls: ['./medical-school.component.css']
})
export class MedicalSchoolComponent implements OnInit {
    medicalSchools: MedicalSchool[]
    medicalSchool: MedicalSchool = {}
    
    constructor(private medicalSchoolService: MedicalSchoolService) { }

    ngOnInit() {
        this.getMedicalSchools()
    }

    getMedicalSchools() {
        this.medicalSchoolService.getMedicalSchools().subscribe((data: MedicalSchool[]) => {
            //console.log(data);
            this.medicalSchools = data;
        }, (error) => { console.log(error) });
    }

    addMedicalSchool() {
        this.medicalSchoolService.addMedicalSchool(this.medicalSchool).subscribe(data => {
            this.medicalSchools.push(data)
            this.medicalSchool = {}
        }, (error) => { console.log(error) })
    }

    clearMedicalSchool() {
        this.medicalSchool = {}
    }

}
