﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public class SquareRootOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count >= 1)
            {
                Decimal num1 = stack.Pop();
                Decimal result = (Decimal) Math.Sqrt((double)num1);
                stack.Push(result);
            }
        }
    }
}