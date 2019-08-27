using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ErrorHandlingExample
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Get the most recent error in the application,
            // the error that caused this handler to run.
            Exception exc = Server.GetLastError();

            // If the error is an unhandled exception that
            // Web Forms is propagating through its error
            // handlers...
            if (exc is HttpUnhandledException)
            {
                // Then, redirect the request to ServerError.aspx.
                Server.Transfer("MissingPage.aspx");
            }
        }
    }
}