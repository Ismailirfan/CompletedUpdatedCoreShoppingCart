using CoreShoppingCart.Areas.Identity.Data;
using CoreShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingCart.Controllers
{
	public class AuthenticationController : Controller
	{
		SCartDbContext db;
		public AuthenticationController (SCartDbContext dbc)
		{
			db=dbc;
		}
		[HttpGet]
		public IActionResult Registration()

		{
			return View();
		}
        [HttpPost]
        public IActionResult Registration(Login lg)
        {
			db.UserLogin.Add(lg);
			db.SaveChanges();
			ViewBag.m="Account Created Successfully";
            return View();
        }
    }
}
