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
    public partial class PatronList : BaseControl
    {
        public string addPatronUrl { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!CustomUser.IsLibrarian)
            {
                PatronAddLink.Visible = false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PatronAddLink.NavigateUrl = addPatronUrl;
            if (!IsPostBack)
            {
                DataTable dt;
                if (CustomUser.IsLibrarian)
                {
                    dt = DatabaseHelper.Retrieve(@"
                    Select FirstName, LastName, Email, LibraryCardNumber, Address, Zipcode, State
                    From Patron
                    ");
                }
                else
                {
                    int libraryCardNumber = int.Parse(CustomUser.Identity.Name);
                    dt = DatabaseHelper.Retrieve(@"
                    Select FirstName, LastName, Email, LibraryCardNumber, Address, Zipcode, State
                    From Patron where LibraryCardNumber = @LibraryCardNumber
                    ", new SqlParameter("@LibraryCardNumber", libraryCardNumber));
                }
                
                Patrons.DataSource = dt.Rows;
                Patrons.DataBind();
            }
        }
    }
}