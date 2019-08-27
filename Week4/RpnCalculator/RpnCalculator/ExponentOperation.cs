using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class ExponentOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 2)
            {
                Decimal num1 = stack.Pop();
                Decimal num2 = stack.Pop();
                Decimal result = (Decimal)Math.Pow((double)num2, (double)num1);
                stack.Push(result);
            }
        }
    }
}