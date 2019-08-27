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

        public string PerformOperation(OperationType operationType)
        {
            IOperation operation = null;
            switch (operationType)
            {
                case OperationType.ADD:
                    operation = new AddOperation();
                    break;
                case OperationType.MINUS:
                    operation = new SubtractOperation();
                    break;
                case OperationType.MULTIPLY:
                    operation = new MultiplyOperation();
                    break;
                case OperationType.DIVIDE:
                    operation = new DivideOperation();
                    break;
                case OperationType.NEGATE:
                    operation = new NegateOperation();
                    break;
                case OperationType.SQROOT:
                    operation = new SquareRootOperation();
                    break;
                case OperationType.EXPONENT:
                    operation = new ExponentOperation();
                    break;
                case OperationType.NATURAL:
                    operation = new NaturalOperation();
                    break;
                case OperationType.RECIPROCAL:
                    operation = new ReciprocalOperation();
                    break;
                case OperationType.SIN:
                    operation = new SinOperation();
                    break;
                case OperationType.COS:
                    operation = new CosOperation();
                    break;
                
            }
            if (operation != null)
            {
                try
                {
                    operation.Perform(CalcStack);
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
                
            }
            return string.Empty;
        }

        public void Drop()
        {
            CalcStack.Pop();
        }
        public void Clear()
        {
            CalcStack.Clear();
        }
        public void Swap()
        {
            Decimal top = CalcStack.Pop();
            Decimal next = CalcStack.Pop();
            CalcStack.Push(top);
            CalcStack.Push(next);
        }
        public void Rotate()
        {
            Decimal a = CalcStack.Pop();
            Decimal b = CalcStack.Pop();
            Decimal c = CalcStack.Pop();
            CalcStack.Push(a);
            CalcStack.Push(c);
            CalcStack.Push(b);
        }
    }
}