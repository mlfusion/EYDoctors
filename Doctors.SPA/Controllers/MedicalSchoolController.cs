using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctors.Business;
using Doctors.Models;
using Doctors.SPA.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doctors.SPA.Controllers
{
    [Route("api/[controller]")]
    public class MedicalSchoolController : Controller
    {
        public IMedicalSchoolBus _medicalSchoolBus { get; set; }
        public IMapper _mapper { get; set; }

        public MedicalSchoolController(IMedicalSchoolBus medicalSchoolBus, IMapper mapper)
        {
            _mapper = mapper;
            _medicalSchoolBus = medicalSchoolBus;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalSchoolDto>>> Get()
        {
            try
            {
                var res = await _medicalSchoolBus.GetMedicalSchools();

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<IEnumerable<MedicalSchoolDto>>(res);

                return Ok(map);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetMedicalSchoolById")]
        public async Task<ActionResult<MedicalSchoolDto>> Get(int id)
        {
            try
            {
                var res = await _medicalSchoolBus.GetMedicalSchool(id);

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<MedicalSchoolDto>(res);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<MedicalSchoolDto>> Post([FromBody] MedicalSchoolDto medicalSchoolDto)
        {
            try
            {
                if (medicalSchoolDto == null)
                    return BadRequest("Language object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var map = _mapper.Map<MedicalSchool>(medicalSchoolDto);

                var res = await _medicalSchoolBus.AddMedicalSchool(map);

                var revMap = _mapper.Map<MedicalSchoolDto>(res);

                return CreatedAtRoute("GetMedicalSchoolById", new { id = res.Id }, revMap);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


    }
}
