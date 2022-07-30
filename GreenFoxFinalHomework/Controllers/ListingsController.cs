using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenFoxFinalHomework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenFoxFinalHomework.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingService listings;
        private readonly IUserService user;
        public ListingsController(IListingService listing, IUserService user)
        {
            this.listings = listing;
            this.user = user;
        }

        [Route("listings")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/list")]
        public IActionResult ViewListings()
        {
            return Json(listings.ListItems());
        }

    }
}

