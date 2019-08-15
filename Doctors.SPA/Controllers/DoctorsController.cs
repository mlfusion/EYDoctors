using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctors.Business;
using Doctors.Models;
using Doctors.SPA.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doctors.SPA.Controllers
{
    [Route("api/[controller]")]
    public class DoctorsController : Controller
    {
        public IDoctorBus _doctorBus { get; set; }
        public ISpecialtyBus _specialtyBus { get; set; }
        public IMapper _mapper { get; set; }

        public DoctorsController(IDoctorBus doctorBus, ISpecialtyBus specialtyBus, IMapper mapper)
        {
            _mapper = mapper;
            _specialtyBus = specialtyBus;
            _doctorBus = doctorBus;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDetailsDto>>> Get()
        {
            try
            {
                var res = await _doctorBus.GetDoctors();

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<IEnumerable<DoctorDetailsDto>>(res);

                return Ok(map);
            }
            catch (Exception ex)
            {
                // bese practice is to creae a global exception handler
                return StatusCode(500, ex.InnerException == null ? ex.Message : ex.InnerException.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDoctorById")]
        public async Task<ActionResult<DoctorDetailsDto>> Get(int id)
        {
            try
            {
                var res = await _doctorBus.GetDoctor(id);

                if (res == null)
                    return NoContent();

                // get average ratings
                //var averageRatings = "";
                //res.PatientRating.ToList().ForEach(x => { averageRatings += $"{x.Rating}0";  });
                
                var doctorDto = _mapper.Map<DoctorDetailsDto>(res);

                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException == null ? ex.Message : ex.InnerException.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Post([FromBody] DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                    return BadRequest("Doctor object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                // TODO: It's best pratice to use AutoMapper
                Doctor doctor = new Doctor()
                {
                    Gender = doctorDto.Gender,
                    Name = doctorDto.Name,
                    LanguageId = doctorDto.LanguageId,
                    MedicalSchoolId = doctorDto.MedicalSchoolId
                };

                var res = await _doctorBus.AddDoctor(doctor);

                if (res != null)
                {
                    DoctorSpecialty doctorSpecialty = new DoctorSpecialty()
                    {
                        DoctorId = res.Id,
                        SpecialtyId = doctorDto.SpecialtyId
                    };
                    await _doctorBus.AddDoctorSpecialty(doctorSpecialty);
                }

                var newDoc = await _doctorBus.GetDoctor(res.Id);

                return CreatedAtRoute("GetDoctorById", new { id = res.Id }, newDoc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException == null ? ex.Message : ex.InnerException.ToString());
            }
        }
    }
}
