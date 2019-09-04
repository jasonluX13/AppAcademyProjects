using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public class BasePage : System.Web.UI.Page
    {
        protected CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
    }
}