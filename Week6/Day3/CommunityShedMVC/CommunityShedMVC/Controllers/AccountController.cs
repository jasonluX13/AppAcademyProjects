using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CommunityShedMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            //Validate that the provided email isn't already in use

            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(viewModel.Password, 12);
                DatabaseHelper.Insert(@"
                    insert into Person (
                        FirstName,
                        LastName,
                        Email,
                        Password)
                    values (
                        @FirstName,
                        @LastName,
                        @Email,
                        @Password)
                ",
                new SqlParameter("@FirstName", viewModel.FirstName),
                new SqlParameter("@LastName", viewModel.LastName),
                new SqlParameter("@Email", viewModel.Email),
                new SqlParameter("@Password", hashedPassword));

                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                Person person = DatabaseHelper.RetrieveSingle<Person>(@"
                        select Password from Person 
                        where Email = @Email
                ", new SqlParameter("@Email", viewModel.Email));
                if (person == null || !BCrypt.Net.BCrypt.Verify(viewModel.Password, person.Password))
                {
                    ModelState.AddModelError("", "The password or email is incorrect.");
                }

            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}