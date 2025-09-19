// 代码生成时间: 2025-09-19 13:53:19
using System;

namespace MathUtilities
{
    public static class MathCalculationUtility
    {
        // Adds two numbers together.
        public static double Add(double a, double b)
        {
            try
            {
                return a + b;
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException("The sum is too large or too small to be represented.");
            }
        }

        // Subtracts one number from another.
        public static double Subtract(double a, double b)
        {
            try
            {
                return a - b;
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException("The result is too large or too small to be represented.");
            }
        }

        // Multiplies two numbers together.
        public static double Multiply(double a, double b)
        {
            try
            {
                return a * b;
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException("The product is too large or too small to be represented.");
            }
        }

        // Divides one number by another. Returns NaN if the denominator is zero.
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            try
            {
                return a / b;
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException("The quotient is too large or too small to be represented.");
            }
        }
    }
}
