using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class DivideOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 2)
            {
                Decimal num1 = stack.Pop();
                Decimal num2 = stack.Pop();
                Decimal result = num2 / num1;
                stack.Push(result);
            }
        }
    }
}