using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public interface IOperation
    {
        void Perform(Stack<Decimal> stack);
    }
}