using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Library : System.Web.UI.MasterPage
    {
        protected CustomPrincipal CustomUser
        {
            get
            {
                if (Request.IsAuthenticated)
                {
                    return (CustomPrincipal)this.Page.User;
                }
                return null;   
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CustomUser != null)
            {
                if (CustomUser.IsLibrarian)
                {
                    Librarian.Visible = true;
                }
                else
                {
                    Librarian.Visible = false;
                }
            }
           
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}