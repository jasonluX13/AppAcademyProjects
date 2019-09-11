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
    public class CommentController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlogDatabase"].ConnectionString;
        // GET: Comment
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create(int? postId)
        {
            if (postId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Comment comment = new Comment();
            comment.PostId = (int)postId;
            return View(comment);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            try
            {
                // TODO: Add insert logic here
                comment.CreatedOn = DateTime.Now;
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
                    comment.CreatorId = reader.GetInt32(0);
                }

                //Create the comment
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    string sql = @"
                //        Insert into Comment(Text, CreatedOn, CreatorId)
                //        values (@Text, @CreatedOn, @CreatorId)
                        
                //     ";
                //    SqlCommand command = new SqlCommand(sql, connection);
                //    command.Parameters.AddWithValue("@Text", post.Text);
                //    command.Parameters.AddWithValue("@CreatedOn", post.CreatedOn);
                //    command.Parameters.AddWithValue("@CreatorId", post.CreatorId);

                //    command.ExecuteNonQuery();
                //}
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
