using Library.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class AuthorList : System.Web.UI.UserControl
    {
        public string AddAuthorUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorAddLink.NavigateUrl = AddAuthorUrl;
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Id, FirstName, LastName
                    from Author
                    order by LastName, FirstName
                ");

                Authors.DataSource = dt.Rows;
                Authors.DataBind();
            }
        }

        
    }
}