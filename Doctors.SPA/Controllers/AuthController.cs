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
    public class AuthController : Controller
    {
        public IMapper _mapper { get; set; }
        public IUserBus _user { get; set; }

        public AuthController(IUserBus user, IMapper mapper)
        {
            this._user = user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null)
                    return BadRequest("Doctor object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var mapUser = _mapper.Map<User>(userDto);

                if (!await _user.ValidateUser(mapUser))
                    return NotFound();

                return Ok("user is validate");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException == null ? ex.Message : ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register([FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null)
                    return BadRequest("Doctor object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var mapUser = _mapper.Map<User>(userDto);

                if (await _user.IsUserNameExist(mapUser))
                    return BadRequest("Username is already taken.");

                await _user.AddUser(mapUser);

                return Ok("Your account was was created successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException == null ? ex.Message : ex.InnerException.ToString());
            }
        }

    }
}
