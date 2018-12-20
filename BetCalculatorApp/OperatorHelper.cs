using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BetCalculatorApp
{
    public static class OperatorHelper
    {
        public static double Calculate(double value1, double value2, string myoperator)
        {
            double result = 0;
            switch (myoperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }
            return result;
        }
    }
}