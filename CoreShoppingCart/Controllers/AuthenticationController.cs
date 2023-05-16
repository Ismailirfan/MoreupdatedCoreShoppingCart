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
			var x = from i in db.UserLogin
					where i.Email.Contains(lg.Email)
					select i;
			if(x.Any())
			{
				ViewBag.m="Email id already access";
				return View();
			}
			else
			{
                db.UserLogin.Add(lg);
                db.SaveChanges();
                ViewBag.m="Account Created Successfully";
                return View("Login");
            }
			
        }
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Login(Login l)
        {
			var x =from a in db.UserLogin
				   where a.Email.Equals(l.Email) && a.Password.Equals(l.Password)
				   select a;
			if(x.Any())
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.m="Email id or Password not matched";
			}
            return View();
        }

    }
}
