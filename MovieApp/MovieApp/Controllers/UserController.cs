using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Models.Data;
using Movies.DAL.Models.Dto;
using Movies.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("create")]
        public ActionResult<string> CreateNewUser([FromBody] UserDto user)
        {
            try
            {
                return Ok(_userService.CreateNewUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<List<UserDto>> GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<UserDto> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("updateuser")]
        public ActionResult UpdateUser([FromBody] UserDto user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
