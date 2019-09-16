using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Librarian : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!CustomUser.IsLibrarian)
            {
                Response.Redirect("~/NotAuthorized.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}