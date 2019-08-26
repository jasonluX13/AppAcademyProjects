using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RpnCalculator
{
    public partial class CalculatorUI : System.Web.UI.Page
    {
        private string CalculatorKey = "Calculator";
        protected Calculator MainCalculator
        {
            get
            {
                Calculator calc = (Calculator) ViewState[CalculatorKey];
                return calc;
            }
            set
            {
                ViewState[CalculatorKey] = value;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                MainCalculator = new Calculator();
            }
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            string[] fourEntries = MainCalculator.GetFourEntries();
            //Decimal[] fourEntries = { 1 , 2, 3, 4};
            StackViewer.DataSource = fourEntries;
            StackViewer.DataBind();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string[] fourEntries = MainCalculator.GetFourEntries();
                //Decimal[] fourEntries = { 1 , 2, 3, 4};
                StackViewer.DataSource = fourEntries;
                StackViewer.DataBind();
            }
            
        }

        protected void Handle_Enter(object sender, EventArgs e)
        {
            Decimal entry;
            if (Decimal.TryParse(NumberInput.Text, out entry))
            {
                MainCalculator.Push(entry);
                NumberInput.Text = "";
            }
        }


        protected void HandleAdd(object sender, EventArgs e)
        {

        }
        protected void HandleMinus(object sender, EventArgs e)
        {

        }
        protected void HandleMultiply(object sender, EventArgs e)
        {

        }
        protected void HandleDivide(object sender, EventArgs e)
        {

        }
        protected void HandleNegate(object sender, EventArgs e)
        {

        }
        protected void HandleDrop(object sender, EventArgs e)
        {

        }
    }
}