using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Controls
{
    public class BaseControl : System.Web.UI.UserControl
    {
        protected CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)Context.User;
            }
        }
    }
}