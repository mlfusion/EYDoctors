import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { DoctorService } from '../../_services/doctor.service';
import { Doctor, PatientRating } from '../../_models/models';
import { PatientRatingService } from '../../_services/patient-review.service';

@Component({
    selector: 'app-doctor-detail',
    templateUrl: './doctor-detail.component.html',
    styleUrls: ['./doctor-detail.component.css']
})
export class DoctorDetailComponent implements OnInit {
    id: any;
    doctor: Doctor;
    comments: string;
    ratings: any[] = [1, 2, 3, 4, 5];
    selectedOption: any;
    patientRating: PatientRating;

    constructor(private route: ActivatedRoute, private doctorService: DoctorService, private patientReviewService: PatientRatingService) { }

    ngOnInit() {

        this.id = this.route.snapshot.params.id;

        this.doctorService.getDoctor(this.id).subscribe(data => {
          //  console.log(data);
            this.doctor = data;
        }, (error) => {
            console.log(error);
        })
    }

    addReview() {

        this.patientRating =  {
            doctorId: this.doctor.id,
            comments: this.comments,
            rating: this.selectedOption
        };

        console.log(this.patientRating);
                  
        this.patientReviewService.addPatientRating(this.patientRating).subscribe(data => {
            this.doctor.patientRatings.push(data);

            this.clearReview();

           // console.log(data);
        }, (error) => {
            console.log(error);
        });


    }

    clearReview() {
        this.comments = "";
        this.selectedOption = "";
    }

}
