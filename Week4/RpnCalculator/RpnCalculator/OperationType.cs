using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator
{
    public enum OperationType
    {
        ADD,
        MINUS,
        MULTIPLY,
        DIVIDE,
        NEGATE,
        SQROOT,
        NATURAL, //e^x
        EXPONENT, //y^x
        RECIPROCAL, // 1/x
        SIN, 
        COS
    }
}