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
    public partial class PatronList : System.Web.UI.UserControl
    {
        public string addPatronUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PatronAddLink.NavigateUrl = addPatronUrl;
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                Select FirstName, LastName, Email, LibraryCardNumber, Address, Zipcode, State
                From Patron
                ");
                Patrons.DataSource = dt.Rows;
                Patrons.DataBind();
            }
        }
    }
}