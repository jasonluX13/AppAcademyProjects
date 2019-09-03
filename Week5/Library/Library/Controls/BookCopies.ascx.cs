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
    public partial class BookCopies : System.Web.UI.UserControl
    {
        protected int BookId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out BookId))
            {
                Response.Redirect("~/Book.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select BookCopy.Id, Title, ISBN, FirstName, LastName, BranchName, Out, Available
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    where Book.Id = @BookId
                    order by Title
                ",
                new SqlParameter("@BookId", BookId));

                Results.DataSource = dt.Rows;
                Results.DataBind();
            }
        }
    }
}