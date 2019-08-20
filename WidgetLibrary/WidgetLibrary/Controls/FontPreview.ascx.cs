using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary.Controls
{
    public partial class FontPreview : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SelectFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string font = SelectFont.SelectedValue;
            Style style = new Style();
            style.Font.Name = font;
            PreviewText.ApplyStyle(style);
            
        }
    }
}