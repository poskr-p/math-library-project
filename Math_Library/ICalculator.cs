using System;

namespace Math_Library
{
    
    public interface ICalculator
    {
        
        double Add(double a, double b);

       
        double Subtract(double a, double b);

       
        double Multiply(double a, double b);

       
        double Divide(double a, double b);

        
        double Power(double number, double power);

       
        long Factorial(int n);

        
        bool IsPrime(int number);

        bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2);
        double CircleArea(double radius);
        double CelsiusToFahrenheit(double celsius);
        double FahrenheitToCelsius(double fahrenheit);
        double Hypotenuse(double a, double b);
    }
}