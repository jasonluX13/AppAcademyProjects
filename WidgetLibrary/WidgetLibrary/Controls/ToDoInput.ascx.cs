using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class ToDoInput : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ToDoData.AddItem(Description.Text);
            Description.Text = "";
            Response.Redirect(Request.RawUrl);
        }
    }
}