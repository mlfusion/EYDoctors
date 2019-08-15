import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../_services/doctor.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Doctor, Language, MedicalSchool, Specialty } from '../../_models/models';
import { LanguageService } from '../../_services/language.service';
import { SpecialtyService } from '../../_services/specialty.service';
import { MedicalSchoolService } from '../../_services/medical-school.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '../../../../node_modules/@angular/forms';

@Component({
    selector: 'app-doctor-list',
    templateUrl: './doctor-list.component.html',
    styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {
    doctors: Doctor[];
    doctor: any = { gender: null, languageId: null, medicalSchoolId: null, specialtyId: null }
    name: any;
    selectedGenderOption?: any = null;
    selecteLanguageOption?: any = null;
    selectedMedicalSchoolOption?: any = null;
    selectedSpecialtyOption?: any = null;
    genders?= ['female', 'male'];
    language: Language[]; // = ['CHINESE', 'SPANISH', 'ENGLISH', 'HINDI', 'ARABIC', 'PORTUGUESE', 'BENGALI', '', '', '', ''];
    medicalSchool: MedicalSchool[];
    specialty: Specialty[];


    constructor(private doctorService: DoctorService, private route: ActivatedRoute,
        private languageService: LanguageService, private specialtyService: SpecialtyService,
        private medicalSchoolService: MedicalSchoolService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.route.data.subscribe(data => {
            //console.log(this.selectedOption)
            this.doctors = data.doctors;
        })

        // get languages list
        this.getlanguages();

        // get medical schools list
        this.getMedicalSchools();

        // get specialties list
        this.getSpecialties();

    }

    getDoctors() {
        this.doctorService.getDoctors().subscribe(data => {
            this.doctors = data;
        })
    }


    addDoctor() {

        // console.log(this.doctor)

        this.doctorService.addDoctor(this.doctor).subscribe(data => {
            // console.log(data);
            //this.doctors.push();
            this.getDoctors();
            this.clearDoctor();
        }, (error) => { console.log(error) });
    }

    clearDoctor() {
        this.doctor = { gender: null, languageId: null, medicalSchoolId: null, specialtyId: null }
    }

    getlanguages() {
        this.languageService.getLanguages().subscribe((data: Language[]) => {
            //console.log(data);
            this.language = data;
        }, (error) => { console.log(error) });
    }

    getMedicalSchools() {
        this.medicalSchoolService.getMedicalSchools().subscribe((data: MedicalSchool[]) => {
            //console.log(data);
            this.medicalSchool = data;
        }, (error) => { console.log(error) });
    }


    getSpecialties() {
        this.specialtyService.getSpecialtys().subscribe((data: Specialty[]) => {
            //console.log(data);
            this.specialty = data;
        }, (error) => { console.log(error) });
    }

}
