using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreenFoxFinalHomework.Services.Interfaces;
using GreenFoxFinalHomework.Models.DTOs;
using GreenFoxFinalHomework.Services;
using Microsoft.AspNetCore.Authorization;

namespace GreenFoxFinalHomework.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            UserDTO currentUser = userService.CheckIfUserIsValid(user);
            if (currentUser != null)
            {
                var token = userService.CreateToken(currentUser);
                return Ok(new UserLoginInfoDTO()
                {
                    Message = "Login was succesful",
                    UserId = currentUser.UserId,
                    Username = currentUser.UserName,   
                    Token = token
                });
            }
            return BadRequest("Invalid UserName or Password");
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult AuthorizePlayerIdentity([FromHeader] string authorization)
        {
            var currentUser = userService.GetCurrentUser(authorization);
            var response = new
            {
                UserId = currentUser.UserId,
                Username = currentUser.Username,
            };

            return Json(response);
        }

        [HttpPost("registration")]
        public IActionResult PlayerRegistration([FromBody] UserRegistrationDTO user)
        {
            if (userService.IsPasswordTooShort(user))
            {
                var errorMessage = new { error = "Your password is too short" };
                return Json(errorMessage);
            }
            if (userService.IsUsernameTaken(user))
            {
                var errorMessage = new { error = "Either you have not entered your username or the username you have chosen is unfortunately taken" };
                return Json(errorMessage);
            }
            UserRegistrationDTO registeredPlayer = userService.RegisterUser(user);
            var response = new
            {
                username = registeredPlayer.Username,
            };
            return Json(response);

        }
    }
}

