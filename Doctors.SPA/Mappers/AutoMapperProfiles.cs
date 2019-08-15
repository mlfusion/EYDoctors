using System;
using AutoMapper;
using Doctors.Models;
using Doctors.SPA.Dtos;
using System.Collections.Generic;

namespace Doctors.SPA.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Doctor, DoctorDetailsDto>()
                .ForPath(dest => dest.Specialty.Name, opt =>
                {
                    opt.MapFrom(src => src.DoctorSpecialty.Specialty.Name);
                })
                .ForMember(dest => dest.PatientRatings, opt =>
                {
                    opt.MapFrom(src => src.PatientRating);
                }).ReverseMap();

            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<MedicalSchool, MedicalSchoolDto>().ReverseMap();
            CreateMap<Specialty, SpecialtyDto>().ReverseMap();
            CreateMap<PatientRating, PatientRatingDto>().ReverseMap();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<UserDto, User>().ReverseMap();


            CreateMap<PatientRating, PatientRatingDetailDto>().ReverseMap();
        }
    }
}
