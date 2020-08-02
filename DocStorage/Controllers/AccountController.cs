using DocStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DocStorage.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            //var session = NHibernateHelper.OpenSession();
            return View(new LoginDto());
        }

        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {

            var user = IsValidCred(loginDto.Login, loginDto.Password);
            if (user != null)
            {
                var userCookie = new HttpCookie("user")
                {
                    Value = Server.UrlEncode(user.FullName),
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.SetCookie(userCookie);
                return Redirect("/Doc/Index");
            }
            else
            {
                return View(new LoginDto());
            }
        }

        private UserDoc IsValidCred(string login, string password)
        {
            var session = NHibernateHelper.OpenSession();
            var user = session.Query<UserDoc>()
                .Where(u => u.Login == login &&
                    u.Password == password)
                .FirstOrDefault();

            return user;
        }
    }
}