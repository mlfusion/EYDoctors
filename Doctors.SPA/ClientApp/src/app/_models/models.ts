export interface Doctor {
    id?: number,
    name?: string,
    gender?: string,
    language?: Language,
    medicalSchool?: MedicalSchool,
    specialty?: Specialty,
    patientRatings?: PatientRating[]
}

export interface Language {
    id?: number,
    name?: string
}

export interface MedicalSchool {
    id?: number,
    name?: string
}

export interface Specialty {
    id?: number,
    name?: string
}

export interface PatientRating {
    doctorId?: number,
    comments?: string,
    rating?: number
}
