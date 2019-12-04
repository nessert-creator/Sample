using CourseManager.Models;
using CourseManager.Models.ValidatableObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.Controllers
{
    public class AccountController : Controller
    {

        private CourseManagerEntities db = new CourseManagerEntities();


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        [HttpPost]
        public ActionResult Login(LoginInput input)
        {
            if (ModelState.IsValid)
            {
                var password = input.Password.MD5Encoding();
                var user = db.Users.FirstOrDefault(u => u.Account == input.Account && u.Password == password);

                if (user == null)
                {
                    ModelState.AddModelError("Password", "用户名不存在或密码输入错误");
                    return View(input);
                }

                HttpContext.Session?.Add("user", user.Account);

                var cookie = new HttpCookie("user", user.Account.EncryptQueryString())
                {
                    Expires = DateTime.Now.AddHours(3)
                };
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }

            return View(input);
        }

    }
}