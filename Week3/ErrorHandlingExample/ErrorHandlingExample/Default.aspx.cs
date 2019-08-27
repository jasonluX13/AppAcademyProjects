using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ErrorHandlingExample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sum_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(Number1.Text, out num1) && int.TryParse(Number2.Text, out num2))
            {
                int result = num1 + num2;
                System.Diagnostics.Debug.Assert(result != 21);
                Result.Text = "Result: " +  result.ToString();
                Trace.Write("Result", result.ToString());
            }
            else
            {
                Trace.Warn("ParsingError", "Could not parse both numbers");
            }
            
        }
    }
}