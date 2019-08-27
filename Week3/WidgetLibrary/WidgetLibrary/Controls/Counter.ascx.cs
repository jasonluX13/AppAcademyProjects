using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary.Controls
{
    public partial class Counter : System.Web.UI.UserControl
    {
        private int Count {
            get
            {
                object o = ViewState["Count"];
                return (o == null) ? 0 : (int)o;
            }
            set
            {               
                ViewState["Count"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CountLabel.Text = Count.ToString();
        }

        protected void Down_Click(object sender, EventArgs e)
        {
            Count--;
            CountLabel.Text = Count.ToString();
        }

        protected void Up_Click(object sender, EventArgs e)
        {
            Count++;
            CountLabel.Text = Count.ToString();
        }
    }
}