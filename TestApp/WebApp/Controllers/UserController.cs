using BusinessLogic.ViewModel;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            List<UserViewModel> users = new List<UserViewModel>()
            {
                 new UserViewModel()
                {
                    Id=1,
                    UserName="Admin",
                    Password="123",
                    Role=UserRole.Admin.ToString()
                },
                new UserViewModel()
                {
                    Id=2,
                    UserName="Worker",
                    Password="123",
                    Role=UserRole.Worker.ToString()
                }

            };

            if (ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    if (user.UserName == model.UserName && user.Password == model.Password)
                    {
                        Session["Login"] = user;
                        return RedirectToAction("Index", "Manage");
                    }
                }

                return View(model);
            }
            return View(model);
        }
      


        public ActionResult LogOut()
        {
            Session["Login"] = null;

            return RedirectToAction("Login");
        }
    }
}