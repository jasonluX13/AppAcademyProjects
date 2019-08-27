using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class NegateOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 1)
            {
                Decimal num1 = stack.Pop();
                Decimal result = num1 * -1;
                stack.Push(result);
            }
        }
    }
}