using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Refactored.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequestModel requestModel)
        {
            try
            {
                _userService.Register(requestModel);
                return Ok(new { message = "User successfully created" });
            }
            catch (Exception )
            {

                throw;
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequestModel requestModel)
        {
            try
            {
                var user = _userService.Authenticate(requestModel);
                if (user == null)
                {
                    return NotFound("Username or Password is incorect!");
                }
                return Ok(user);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
