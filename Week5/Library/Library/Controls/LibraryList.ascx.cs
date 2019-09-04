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
    public partial class LibraryList : BaseControl
    {
        public string addLibraryUrl { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!CustomUser.IsLibrarian)
            {
                LibraryAddLink.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LibraryAddLink.NavigateUrl = addLibraryUrl;
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                Select Id, BranchName, Address, Zipcode, State
                From Library
                ");
                Libraries.DataSource = dt.Rows;
                Libraries.DataBind();
            }
        }

    }
}