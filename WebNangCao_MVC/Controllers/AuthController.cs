using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebNangCao_MVC.Models.Auth;

namespace WebNangCao_MVC.Controllers
{
    public class AuthController : Controller
    {
        public static List<UserLogin> users = new List<UserLogin>();
        public AuthController()
        {

        }
        public IActionResult Login()
        {   
            return View("Auth");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin request)
        {
            //(users.Any(prod => prod.userName == userName)
            if (ModelState.IsValid &&
                (users.Any(prod => prod.userName == request.userName) && users.Any(prod => prod.password == request.password)))
            {
                HttpContext.Session.SetInt32("isLogin", 1);

                HttpContext.Session.SetString("userName", request.userName);
                HttpContext.Session.SetString("password", request.password);
                HttpContext.Session.SetInt32("role", ((int)users[users.FindIndex(prod => prod.userName == request.userName)].role));

                return RedirectToAction("Index", "Home");
            }
            return View("Auth");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("userName", "");
            HttpContext.Session.SetString("password", "");
            HttpContext.Session.SetInt32("isLogin", 0);
            HttpContext.Session.SetInt32("role", 0);
            return RedirectToAction("Index", "Home");
        }
    }
}
