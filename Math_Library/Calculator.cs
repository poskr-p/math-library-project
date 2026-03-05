using Math_Library;

public class Calculator : ICalculator
{
    #region базовые операции

    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("делитель не может быть равен нулю");
        return a / b;
    }

    #endregion

    #region математические функции

    public double Power(double number, double power) => Math.Pow(number, power);

    public long Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("факториал отрицательного числа не определён");
        if (n > 20)
            throw new ArgumentException("факториал больше 20 вызывает переполнение");

        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }

    #endregion

    #region решение уравнений

    public bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
    {
        x1 = null;
        x2 = null;

        if (double.IsNaN(a) || double.IsInfinity(a) ||
            double.IsNaN(b) || double.IsInfinity(b) ||
            double.IsNaN(c) || double.IsInfinity(c))
        {
            throw new ArgumentException("коэффициенты не могут быть NaN или бесконечностью");
        }

        if (a == 0)
        {
            if (b == 0)
                return c == 0;
            x1 = -c / b;
            return true;
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
            return false;

        if (Math.Abs(discriminant) < 1e-10)
        {
            x1 = -b / (2 * a);
            x2 = x1;
            return true;
        }

        double sqrtD = Math.Sqrt(discriminant);
        x1 = (-b + sqrtD) / (2 * a);
        x2 = (-b - sqrtD) / (2 * a);
        return true;
    }

    #endregion

   
    public double CircleArea(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("радиус не может быть отрицательным");
        return Math.PI * radius * radius;
    }

    public double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }

    
    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public double Hypotenuse(double a, double b)
    {
        if (a < 0 || b < 0)
            throw new ArgumentException("катеты не могут быть отрицательными");
        return Math.Sqrt(a * a + b * b);
    }
}