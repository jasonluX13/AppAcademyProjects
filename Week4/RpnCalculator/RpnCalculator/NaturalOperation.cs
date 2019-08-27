using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class NaturalOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 1)
            {
                Decimal num1 = stack.Pop();
                Decimal result = (Decimal)Math.Exp( (double)num1);
                stack.Push(result);
            }
        }
    }
}