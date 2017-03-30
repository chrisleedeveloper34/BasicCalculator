using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicCalculator.Maths
{
    public class Calculate
    {
        public static float DoWork(float num1, float num2, char op)
        {
            switch (op)
            {
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 > 0)
                    {
                        return num1 / num2;
                    }
                    else return 0.0F;
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                default:
                    return 0.0F;
            }
        }
    }
}