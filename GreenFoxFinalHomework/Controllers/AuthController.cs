using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreenFoxFinalHomework.Services.Interfaces;


namespace GreenFoxFinalHomework.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

