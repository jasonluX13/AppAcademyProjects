using Blahgger.Data;
using Blahgger.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blahgger.Controllers
{
    public class AccountController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlogDatabase"].ConnectionString;

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                // TODO get the user record from the database


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                      SELECT Id, Email, HashedPassword
                      FROM [User]
                      Where Email = @Email
                    ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!Hashing.ValidatePassword(user.Password, reader.GetString(2)))
                        {
                            ModelState.AddModelError("", "Login failed.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login failed.");
                    }

                }
                // TODO check if the passwords match
                //if (!(user.Email == "james@smashdev.com" && user.Password == "password"))
                //{
                //    ModelState.AddModelError("", "Login failed.");
                //}
            }

            if (ModelState.IsValid)
            {
                // Login the user.
                FormsAuthentication.SetAuthCookie(user.Email, false);

                // Send them to the home page.
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(User user)
        {
            //Check if email already exists
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                      SELECT Id, Email
                      FROM [User]
                      Where Email = @Email
                    ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", user.Email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ModelState.AddModelError("", "Email has already been used");
                }
                else
                {
                    ModelState.AddModelError("", "Email has already been used");
                }

            }
            //Add account to database

            //Redirect to login

            return View();
        }
    }
}