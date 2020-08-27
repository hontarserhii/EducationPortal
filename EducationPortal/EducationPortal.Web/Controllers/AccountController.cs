using EducationPortal.BL.Services.UserServices;
using EducationPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationPortal.Core;
using EducationPortal.DAL.Context;
using System.Web.Security;

namespace EducationPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUser userService;

        public AccountController(IUser user)
        {
            this.userService = user;
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                bool isReg = userService.Registrate(new Core.Entities.User() {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password
                });

                if (isReg == true)
                {
                    //System.Web.Security.FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                int id = userService.Authorizate(model.Login, model.Password);
                if (id > 0)
                {
                    Session["UserId"] = id;
                    FormsAuthentication.SetAuthCookie(model.Login.ToString(), true);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Course");
        }
        public string Index()
        {
            string result = "Вы не авторизованы";
            return result;
        }

        [HttpGet]
        public ActionResult Info()
        {
            var user = this.userService.GetUserInfo(Int32.Parse(Session["UserId"].ToString()));
            return View(user);
        }
    }
}