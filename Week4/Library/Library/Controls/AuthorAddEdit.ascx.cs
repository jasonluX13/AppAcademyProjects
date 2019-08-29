using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class AuthorAddEdit : System.Web.UI.UserControl
    {
        int authorId = 0;
        public bool edit { get; set; }
        public string AuthorList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Author";
                if (!int.TryParse(Request.QueryString["ID"], out authorId))
                {
                    Response.Redirect(AuthorList);
                }

                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select FirstName, LastName
                    from Author
                    where Id = @AuthorId
                ", new SqlParameter("@AuthorId", authorId));

                    if (dt.Rows.Count == 1)
                    {
                        FirstName.Text = dt.Rows[0].Field<string>("FirstName");
                        LastName.Text = dt.Rows[0].Field<string>("LastName");
                    }
                    else
                    {
                        Response.Redirect(AuthorList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Author";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;

            if (edit)
            {
                DatabaseHelper.Update(@"
                update Author set
                    FirstName = @FirstName,
                    LastName = @LastName
                where Id = @AuthorId
            ",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@AuthorId", authorId));
            }
            else
            {
                int? id = DatabaseHelper.Insert(@"
                insert into Author (FirstName, LastName)
                values (@FirstName, @LastName);
            ",
              new SqlParameter("@FirstName", firstName),
              new SqlParameter("@LastName", lastName));

            }

            Response.Redirect(AuthorList);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(AuthorList);
        }
    }
}