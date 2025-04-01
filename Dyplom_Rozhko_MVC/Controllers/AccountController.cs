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
            DyplomEntities db = new DyplomEntities();
            var viewModel = new ConnectAllTables
            {
                Category = db.Category.ToList(),
                Users = db.Users.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(Users users, string NameUser, string RealNameUser, string PhoneNumber, string Email, string Password)
        {
            DyplomEntities db = new DyplomEntities();

            users.Name = RealNameUser;
            users.UserName = NameUser;
            users.Phone= PhoneNumber;
            users.Email = Email;
            users.Password = Password;
            users.RoleId = 1;
            users.CreatedDate = DateTime.Now;
            
            db.Users.Add(users);
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }
    }
}