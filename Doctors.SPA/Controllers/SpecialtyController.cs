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
    public class SpecialtyController : Controller
    {
        public ISpecialtyBus _specialtyBus { get; set; }
        public IMapper _mapper { get; set; }

        public SpecialtyController(ISpecialtyBus specialtyBus, IMapper mapper)
        {
            _mapper = mapper;
            _specialtyBus = specialtyBus;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialtyDto>>> Get()
        {
            try
            {
                var res = await _specialtyBus.GetSpecialtys();

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<IEnumerable<SpecialtyDto>>(res);

                return Ok(map);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSpecialtyById")]
        public async Task<ActionResult<SpecialtyDto>> Get(int id)
        {
            try
            {
                var res = await _specialtyBus.GetSpecialty(id);

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<SpecialtyDto>(res);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<SpecialtyDto>> Post([FromBody] SpecialtyDto specialty)
        {
            try
            {
                if (specialty == null)
                    return BadRequest("Specialty object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var map = _mapper.Map<Specialty>(specialty);

                var res = await _specialtyBus.AddSpecialty(map);

                var revMap = _mapper.Map<SpecialtyDto>(res);

                return CreatedAtRoute("GetSpecialtyById", new { id = res.Id }, revMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
