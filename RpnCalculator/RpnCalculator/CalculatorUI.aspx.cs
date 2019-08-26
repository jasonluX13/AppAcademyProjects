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
                NumberInput.Focus();
            }
            ErrorMessage.Text = string.Empty;
            
        }


        protected void HandleAdd(object sender, EventArgs e)
        {
            ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.ADD);
            
        }
        protected void HandleMinus(object sender, EventArgs e)
        {
            ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.MINUS);
        }
        protected void HandleMultiply(object sender, EventArgs e)
        {
            ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.MULTIPLY);
        }
        protected void HandleDivide(object sender, EventArgs e)
        {
            ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.DIVIDE);
        }
        protected void HandleNegate(object sender, EventArgs e)
        {
            ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.NEGATE);
        }
        protected void HandleDrop(object sender, EventArgs e)
        {
            MainCalculator.Drop();
        }

        protected void HandleOperation(object sender, EventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            Button selected = (Button)sender;
            switch (selected.ID)
            {
                case "SqRoot":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.SQROOT);
                    break;
                case "Natural":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.NATURAL);
                    break;
                case "Exponent":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.EXPONENT);
                    break;
                case "Reciprocal":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.RECIPROCAL);
                    break;
                case "Sin":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.SIN);
                    break;
                case "Cos":
                    ErrorMessage.Text = MainCalculator.PerformOperation(OperationType.COS);
                    break;

            }
        }

        protected void HandleClear(object sender, EventArgs e)
        {
            MainCalculator.Clear();
        }
        protected void HandleSwap(object sender, EventArgs e)
        {
            MainCalculator.Swap();
        }
        protected void HandleRotate(object sender, EventArgs e)
        {
            MainCalculator.Rotate();
        }
    }
}