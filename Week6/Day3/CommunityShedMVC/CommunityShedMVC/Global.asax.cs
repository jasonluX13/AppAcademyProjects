using CommunityShedMVC.Data;
using CommunityShedMVC.Models;
using CommunityShedMVC.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CommunityShedMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest()
        {
            IPrincipal user = HttpContext.Current.User;
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);
                string currentUserEmail = ticket.Name;
                Person person = DatabaseHelper.RetrieveSingle<Person>(@"
                    select Id, FirstName, LastName, Email
                    from Person
                    where Email = @Email
                ", new SqlParameter("@Email", user.Identity.Name));

                person.Roles = DatabaseHelper.Retrieve<PersonRole>(@"
                    select CommunityId, RoleName
                    from PersonRole join [Role] on PersonRole.RoleId = [Role].Id
                    join Community on Community.Id = PersonRole.CommunityId
                    where PersonId = @PersonId
                    order by PersonRole.CommunityId, PersonRole.RoleId
                ", new SqlParameter("@PersonId", person.Id));

                CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, person);
                HttpContext.Current.User = customPrincipal;
                Thread.CurrentPrincipal = customPrincipal;
            }
        }
    }
}
