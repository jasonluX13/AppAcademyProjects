using Blahgger.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blahgger.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CurrentUserEmail = User.Identity.Name;
            List<Post> posts = new List<Post>();
            PopulateList(posts);
            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Directory()
        {
            return View();
        }

        private void PopulateList(List<Post> posts)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BlogDatabase"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                      SELECT Post.Id, Text, CreatedOn, CreatorId, FirstName+' '+LastName as Name
                      FROM Post join [User] on Post.CreatorId = [User].Id 
                    ";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Post post = new Post();
                    post.Id = reader.GetInt32(0);
                    post.Text = reader.GetString(1);
                    post.CreatedOn = reader.GetDateTimeOffset(2);
                    post.CreatorId = reader.GetInt32(3);
                    post.CreatorName = reader.GetString(4);
                    posts.Add(post);
                }

            }
        }
    }
}