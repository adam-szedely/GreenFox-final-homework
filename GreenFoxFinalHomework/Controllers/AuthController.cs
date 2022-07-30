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
        public AuthController()
        {
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

