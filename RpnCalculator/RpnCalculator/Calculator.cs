using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    [Serializable]
    public class Calculator
    {
        private Stack<Decimal> CalcStack = new Stack<decimal>();

        public void Push (Decimal number)
        {
            CalcStack.Push(number);
        }
        
        public string[] GetFourEntries()
        {
            string[] fourEntries = new string[4];
            int count = 3;
            foreach (var item in CalcStack)
            {
                if (count >= 0)
                {
                    fourEntries[count] = item.ToString();
                }
                count--;
            }
            return fourEntries;
        }
    }
}