using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ErrorMessage.Visible = true;
            //ErrorMessage.Text = Hashing.HashPassword("password");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int libraryCardNumber;
            string password = Password.Text;
            if (!int.TryParse(LibraryCardNumber.Text, out libraryCardNumber))
            {
                ErrorMessage.Visible = true;
                return;
            }
            DataTable dt = DatabaseHelper.Retrieve(@"
                Select Password From
                Patron
                Where LibraryCardNumber = @LibraryCardNumber
            ", new SqlParameter("@LibraryCardNumber", libraryCardNumber)); 
            if (dt.Rows.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            string correctHash = dt.Rows[0].Field<string>("Password");
            if (Hashing.ValidatePassword(password, correctHash))
            {
                FormsAuthentication.RedirectFromLoginPage(libraryCardNumber.ToString(), true);
            }
            else
            {
                ErrorMessage.Visible = true;
                return;
            }
        }
    }
}