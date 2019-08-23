using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UglyTicTacToe
{
    public class Base : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            Theme = "ugly1";
            base.OnPreInit(e);
        }
    }
}