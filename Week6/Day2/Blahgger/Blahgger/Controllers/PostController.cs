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
    public class PostController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlogDatabase"].ConnectionString;
        // GET: Post
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            DisplayPost postAndComments = new DisplayPost();
            Post post = new Post();
            //Get the post details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                      SELECT Post.Id, Text, CreatedOn, CreatorId, FirstName+' '+LastName as Name
                      FROM Post join [User] on Post.CreatorId = [User].Id 
                      Where Post.Id = @PostId
                    ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@PostId", id);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                post.Id = reader.GetInt32(0);
                post.Text = reader.GetString(1);
                post.CreatedOn = reader.GetDateTimeOffset(2);
                post.CreatorId = reader.GetInt32(3);
                post.CreatorName = reader.GetString(4);
            }
            postAndComments.Post = post;
            //Get the comments for this post
            List<Comment> comments = new List<Comment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                      SELECT Comment.Id, Post.Id as PostId, Comment.CreatorId, FirstName+' '+LastName as Name, Comment.CreatedOn, Comment.Text
                      FROM Comment join Post on (Comment.PostId = Post.Id) 
                      join [User] on Comment.CreatorId = [User].Id 
                      Where Post.Id = @PostId
                ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@PostId", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Comment comment = new Comment();
                    comment.Id = reader.GetInt32(0);
                    comment.PostId = reader.GetInt32(1);
                    comment.CreatorId = reader.GetInt32(2);
                    comment.CreatorName = reader.GetString(3);
                    comment.CreatedOn = reader.GetDateTimeOffset(4);
                    comment.Text = reader.GetString(5);
                    comments.Add(comment);
                }     
            }
            postAndComments.Comments = comments;

            return View(postAndComments);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Post/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here
                //Set DateTime
                post.CreatedOn = DateTimeOffset.Now;
                //Get creator's id 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                        Select Id From [User]
                        Where Email = @Email 
                     ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Email", User.Identity.Name);                

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    post.CreatorId = reader.GetInt32(0);
                }

                //Create the post
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                        Insert into Post(Text, CreatedOn, CreatorId)
                        values (@Text, @CreatedOn, @CreatorId)
                        
                     ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Text", post.Text);
                    command.Parameters.AddWithValue("@CreatedOn", post.CreatedOn);
                    command.Parameters.AddWithValue("@CreatorId", post.CreatorId);

                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
