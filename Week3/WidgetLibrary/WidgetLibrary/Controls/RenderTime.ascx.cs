using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary.Controls
{
    public partial class RenderTime : System.Web.UI.UserControl
    {
        public string Format { get; set; }
        public string Label { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = "Page rendered at: ";
            string format =  "M/d/yyyy h:mm tt";
            if (!string.IsNullOrEmpty(Format))
            {
                format = Format;
            }
            if (!string.IsNullOrEmpty(Label))
            {
                LabelText.Text = Label;
            }
            text += DateTime.Now.ToString(format);
            Message.Text = text;
            
        }
    }
}