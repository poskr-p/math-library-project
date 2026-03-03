using Math_Library;
using System;

namespace Math_Library
{

    public class Calculator : ICalculator
    {

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }


        public double Multiply(double a, double b)
        {
            return a * b;
        }

 
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("делитель не может быть равен нулю");
            }
            return a / b;
        }

        public double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }

        public long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("факториал отрицательного числа не определён");
            }
            if (n > 20)  
                throw new ArgumentException("факториал больше 20 вызывает переполнение");

            if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

       
        public bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        
        public bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = null;
            x2 = null;

            if (a == 0)
            {
                if (b == 0)
                {
                    
                    return c == 0;
                }

                x1 = -c / b;
                return true;
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return false;
            }
            else if (Math.Abs(discriminant) < 1e-10) 
            {
                x1 = -b / (2 * a);
                x2 = x1;
                return true;
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                x1 = (-b + sqrtDiscriminant) / (2 * a);
                x2 = (-b - sqrtDiscriminant) / (2 * a);
                return true;
            }
        }
    }
}