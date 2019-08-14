using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum ArgumentType
    {
        String,
        Number,
        DateTime,
        TimeSpan
    }
    enum OperatorType
    {
        Unknown,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    class Program
    {
        static void Main(string[] args)
        {
            string supportedOperations = "---------------------------\nUnknown Operation\n\nSupported Operations:\n*Standard mathematics for numerical arguments, \n*String + String, String - String\n*Date / Time - Date / Time => Time Span\n*Date / Time +/ -Time span => Date / Time\n*String* Number => String repeated that number of times";
            Console.WriteLine("Welcome to the Calculator App");
            Console.WriteLine("To quit, type CTRL+C");
            while (true)
            {
                string argument1 = GetArgument("Enter the first argument:");
                ArgumentType argument1Type = GetArgumentType(argument1);

                OperatorType operatorType = GetOperatorType("Enter an operator: (+ , - , * , or /)");
                string argument2 = GetArgument("Enter the second argument:");
                ArgumentType argument2Type = GetArgumentType(argument2);

               
                Console.WriteLine($"Argument1 Type: {argument1Type}");
                Console.WriteLine($"Argument2 Type: {argument2Type}");
                Console.WriteLine($"OperatorType: {operatorType}");

                if (argument1Type ==ArgumentType.Number && argument2Type == ArgumentType.Number)
                {
                    //Regular math operations
                    double arg1 = double.Parse(argument1);
                    double arg2 = double.Parse(argument2);
                    double result = 0;
                    try
                    {
                        switch (operatorType)
                        {
                            case OperatorType.Addition:
                                result = arg1 + arg2;
                                Console.WriteLine($"{arg1} + {arg2} = {result}");
                                break;
                            case OperatorType.Division:
                                result = arg1 / arg2;
                                Console.WriteLine($"{arg1} / {arg2} = {result}");
                                break;
                            case OperatorType.Multiplication:
                                result = arg1 * arg2;
                                Console.WriteLine($"{arg1} * {arg2} = {result}");
                                break;
                            case OperatorType.Subtraction:
                                result = arg1 - arg2;
                                Console.WriteLine($"{arg1} - {arg2} = {result}");
                                break;   
                        }
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else if (argument1Type==ArgumentType.String && argument2Type == ArgumentType.String)
                {
                    if(operatorType==OperatorType.Addition)
                    {
                        Console.WriteLine($"{argument1} + {argument2} = {argument1 + argument2}");
                    }
                    else if (operatorType == OperatorType.Subtraction)
                    {
                        StringBuilder result = new StringBuilder();
                        foreach(char c in argument1)
                        {
                            if (!argument2.Contains(c))
                            {
                                result.Append(c);
                            }
                        }
                        string resultString = result.ToString();
                        Console.WriteLine($"{argument1} - {argument2} = {resultString}");
                    }
                    else
                    {
                        Console.WriteLine(supportedOperations);
                    }
                }
                else if (argument1Type==ArgumentType.DateTime && argument2Type == ArgumentType.DateTime)
                {
                    if (operatorType == OperatorType.Subtraction)
                    {
                        DateTimeOffset arg1 = DateTimeOffset.Parse(argument1);
                        DateTimeOffset arg2 = DateTimeOffset.Parse(argument2);
                        Console.WriteLine($"{arg1} - {arg2} = {arg1 - arg2}");
                    }
                    else
                    {
                        Console.WriteLine(supportedOperations);
                    }
                }
                else if (argument1Type == ArgumentType.DateTime && argument2Type == ArgumentType.TimeSpan)
                {
                    DateTimeOffset arg1 = DateTimeOffset.Parse(argument1);
                    TimeSpan arg2 = TimeSpan.Parse(argument2);
                    if (operatorType==OperatorType.Addition)
                    {
                        
                        Console.WriteLine($"{arg1} + {arg2} = {arg1 + arg2}");

                    }
                    else if (operatorType == OperatorType.Subtraction)
                    {
                        Console.WriteLine($"{arg1} - {arg2} = {arg1 - arg2}");
                    }
                    else
                    {
                        Console.WriteLine(supportedOperations);
                    }
                }
                else if (argument1Type == ArgumentType.String && argument2Type == ArgumentType.Number)
                {
                    if (operatorType == OperatorType.Multiplication)
                    {
                        double count = double.Parse(argument2);
                        while(count > 0)
                        {
                            Console.Write(argument1);
                            count--;
                        }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(supportedOperations);
                    }
                }
                else
                {
                    Console.WriteLine(supportedOperations);
                }
                Console.WriteLine("================================");
            }

        }

        /// <summary>
        /// Get an argument from the user
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <returns>The argument the user enters</returns>
        private static string GetArgument(string message)
        {
            Console.WriteLine(message);
            string argument = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(argument))
            {
                Console.WriteLine(message);
                argument = Console.ReadLine();
            }
            return argument;
        }

        /// <summary>
        /// Returns the type of argument
        /// </summary>
        /// <param name="argument">The selected argument</param>
        /// <returns>The argument type</returns>
        private static ArgumentType GetArgumentType(string argument)
        {
            TimeSpan timespanArgument;
            DateTimeOffset dateTimeArgument;
            double numberArgument;
            if (TimeSpan.TryParse(argument, out timespanArgument))
            {
                return ArgumentType.TimeSpan;
            }
            else if (DateTimeOffset.TryParse(argument, out dateTimeArgument))
            {
                return ArgumentType.DateTime;
            } 
            else if (double.TryParse(argument, out numberArgument))
            {
                return ArgumentType.Number;
            } else
            {
                return ArgumentType.String;
            }

        }

        /// <summary>
        /// Gets the operator type from user
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns>The operator type</returns>
        private static OperatorType GetOperatorType(string message)
        {
            OperatorType opType = OperatorType.Unknown;
            string operatorType = "";
            while (operatorType!="+" && operatorType!="-" && operatorType!="*" && operatorType!="/")
            {
                Console.WriteLine(message);
                operatorType = Console.ReadLine();
            }
            switch (operatorType)
            {
                case "+":
                    opType = OperatorType.Addition;
                    break;
                case "-":
                    opType = OperatorType.Subtraction;
                    break;
                case "*":
                    opType = OperatorType.Multiplication;
                    break;
                case "/":
                    opType = OperatorType.Division;
                    break;
            }
            return opType;
        }
    }
}
