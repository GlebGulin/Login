using Binding.Models;
using NGLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_test.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            using (Db db = new Db())
            {
                var loginSuccess = db.users.Where(x=>x.Login.Equals(loginVM.Login) && x.Pass.Equals(loginVM.PassWord)).FirstOrDefault();
                if (loginSuccess == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                    
                    return View("Login", loginVM);
                }
                else
                {
                    TempData["Success"] = "Success";
                    FormsAuthentication.SetAuthCookie(loginVM.Login, true);
                    return Redirect(FormsAuthentication.GetRedirectUrl(loginVM.Login, true));
                }

            }
                
        }
    }
}