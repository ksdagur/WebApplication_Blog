using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Blog.Models;

namespace WebApplication_Blog.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login//5
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            var dbhandle = new BlogDb();
            dbhandle.Login(lg);
            return View();
        }
    }
}
