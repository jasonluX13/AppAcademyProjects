using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class BookCopyList : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select BookCopy.Id, Title, ISBN, FirstName, LastName, BranchName, Out, Available
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    order by Title
                ");

                BookCopies.DataSource = dt.Rows;
                BookCopies.DataBind();
            }
        }
    }
}