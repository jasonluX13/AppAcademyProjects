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
        public ActionResult Login(LoginUser user)
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
                    //Hash password
                    user.HashedPassword = Hashing.HashPassword(user.Password);
                    //Add account to database
                    AddUser(user);

                    //Redirect to login
                    return RedirectToAction("Login");
                }

            }
            return View();
        }

        private void AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                Insert into [User]  (FirstName, LastName, Email, HashedPassword)
                values (@FirstName, @LastName, @Email, @HashedPassword)
                        
            ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);

                command.ExecuteNonQuery();
            }
        }
    }
}