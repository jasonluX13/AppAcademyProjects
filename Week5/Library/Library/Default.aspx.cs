using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int libraryCardNumber = int.Parse(User.Identity.Name);
            DataTable dt = DatabaseHelper.Retrieve(@"
                Select FirstName + ' ' + LastName as Name
                From Patron 
                Where LibraryCardNumber = @LibraryCardNumber
                ", new SqlParameter("@LibraryCardNumber", libraryCardNumber));
            string name = dt.Rows[0].Field<string>("Name");
            Welcome.Text = "Welcome to the library, " + name;
        }
    }
}