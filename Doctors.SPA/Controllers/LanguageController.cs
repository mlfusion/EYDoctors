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
    public class LanguageController : Controller
    {
        private ILanguageBus _languageBus { get; set; }
        public IMapper _mapper { get; set; }

        public LanguageController(ILanguageBus languageBus, IMapper mapper)
        {
            _mapper = mapper;
            this._languageBus = languageBus;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> Get()
        {
            try
            {
                var res = await _languageBus.GetLanguages();

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<IEnumerable<LanguageDto>>(res);

                return Ok(map);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }    
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLanguageById")]
        public async Task<ActionResult<LanguageDto>> Get(int id)
        {
            try
            {
                var res = await _languageBus.GetLanguage(id);

                if (res == null)
                    return NoContent();

                var map = _mapper.Map<LanguageDto>(res);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<LanguageDto>> Post([FromBody] LanguageDto language)
        {
            try
            {
                if (language == null)
                    return BadRequest("Language object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var map = _mapper.Map<Language>(language);

                var res =  await _languageBus.AddLanguage(map);

                var revMap = _mapper.Map<LanguageDto>(res);

                return CreatedAtRoute("GetLanguageById", new { id = res.Id }, revMap);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }
    }
}
