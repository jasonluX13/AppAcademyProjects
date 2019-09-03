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
    public partial class LibrarianList : System.Web.UI.UserControl
    {   
        public int LibraryCardNumber = int.Parse(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                Select BranchName, Librarian.Id as Id, FirstName, LastName, Email, Librarian.LibraryCardNumber, Patron.Address,  Patron.Zipcode,  Patron.State
                From Librarian join Patron on (Librarian.LibraryCardNumber = Patron.LibraryCardNumber)
                join Library on (Librarian.LibraryId = Library.Id)
                ");
                Librarians.DataSource = dt.Rows;
                Librarians.DataBind();
                
            }
        }
    }
}