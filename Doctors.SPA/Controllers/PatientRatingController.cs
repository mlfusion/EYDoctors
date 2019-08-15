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
    public class PatientRatingController : Controller
    {
        public IPatientRatingBus _patientRating { get; set; }
        public IMapper _mapper { get; set; }

        public PatientRatingController(IPatientRatingBus patientRating, IMapper mapper)
        {
            _mapper = mapper;
            _patientRating = patientRating;
        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] PatientRatingDto patientRatingDto)
        {
            try
            {
                if (patientRatingDto == null)
                    return BadRequest("PatientRating object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var map = _mapper.Map<PatientRating>(patientRatingDto);

                var res = await _patientRating.AddPatientRating(map);

                var resDto = _mapper.Map<PatientRatingDetailDto>(res);

                if (res == null)
                    return NoContent();

                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
