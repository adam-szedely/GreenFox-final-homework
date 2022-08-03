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

        [HttpGet("{id}/list")]
        public IActionResult ViewListings()
        {
            return Json(listings.ListItems());
        }

        [HttpGet("{id}/view")]
        public IActionResult ViewItem(int id)
        {
            if (id == null)
            {
                var error = new { error = "Specify which item!" };
                return StatusCode(401, error);
            }
            return Json(listings.ViewItem(id));
        }

        [HttpPost("{id}/add")]
        public IActionResult CreateItem(string name, string description, string photoUrl, int startingPrice, int id)
        {
            if (string.IsNullOrEmpty(name))
            {
                var error = new { error = "Field name is empty!" };
                return StatusCode(400, error);
            }
            else if (Uri.IsWellFormedUriString(photoUrl, UriKind.RelativeOrAbsolute) == false)
            {
                var error = new { error = $"{photoUrl} is not a valid url!" };
                return StatusCode(400, error);
            }
            return Json(listings.CreateItem(name, description, photoUrl, startingPrice, id));
        }

    }
}

