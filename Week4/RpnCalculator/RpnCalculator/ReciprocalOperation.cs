using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class ReciprocalOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 1)
            {
                Decimal num1 = stack.Pop();
                Decimal result = 1/num1;
                stack.Push(result);
            }
        }
    }
}