using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class AddOperation : IOperation
    {
        public void Perform(Stack<Decimal> stack)
        {
            if (stack.Count >= 2)
            {
                Decimal num1 = stack.Pop();
                Decimal num2 = stack.Pop();
                Decimal result = num1 + num2;
                stack.Push(result);
            }
        }
    }
}