using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Library
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);

                // TODO Get from the database
                int libraryCardNumber = int.Parse(user.Identity.Name);
                DataTable dt = DatabaseHelper.Retrieve(@"
                   Select RoleName From Patron join Roles on Patron.RoleId = Roles.Id
                   where LibraryCardNumber = @LibraryCardNumber     
                 ", new SqlParameter("@LibraryCardNumber", libraryCardNumber));

                //Each user can only have one role
                string[] roles = new string[1];
                roles[0] = dt.Rows[0].Field<string>("RoleName");


                CustomPrincipal principal = new CustomPrincipal(customIdentity, roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}