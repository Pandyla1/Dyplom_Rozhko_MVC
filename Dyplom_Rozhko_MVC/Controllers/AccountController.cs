using Dyplom_Rozhko_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dyplom_Rozhko_MVC.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var viewModel = new ConnectAllTables
            {
                Category = new DyplomEntities().Category.ToList() ?? new List<Category>(),
                Users = new DyplomEntities().Users.ToList(),
                RegisterViewModel = new RegisterViewModel()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ConnectAllTables model)
        {
            if (!ModelState.IsValid)
            {
                using (DyplomEntities db = new DyplomEntities())
                {
                    // Оновлюємо категорії при поверненні на сторінку
                    model.Category = db.Category.ToList();
                }

                return View(model);
            }

            using (DyplomEntities db = new DyplomEntities())
            {
                Users users = new Users
                {
                    Name = model.RegisterViewModel.RealNameUser,
                    UserName = model.RegisterViewModel.NameUser,
                    Phone = model.RegisterViewModel.PhoneNumber,
                    Email = model.RegisterViewModel.Email,
                    Password = model.RegisterViewModel.Password,
                    RoleId = 1,
                    CreatedDate = DateTime.Now
                };

                db.Users.Add(users);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var viewModel = new ConnectAllTables
            {
                Category = new DyplomEntities().Category.ToList() ?? new List<Category>(),
                Users = new DyplomEntities().Users.ToList(),
                RegisterViewModel = new RegisterViewModel()
            };
            return View(viewModel);
        }
    }
}