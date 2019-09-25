using CommunityShedMVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.ViewModels
{
    public class BaseViewModel
    {
        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)HttpContext.Current.User;
            }
        }
    }
}