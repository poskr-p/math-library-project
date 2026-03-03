using Math_Library;

namespace math_library.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();

            Console.WriteLine("== демонстрация работы обновлённого калькулятора ==\n");

            Console.WriteLine("--- базовые операции ---");
            double x = 10, y = 4;

            Console.WriteLine($"сложение: {x} + {y} = {calculator.Add(x, y)}");
            Console.WriteLine($"вычитание: {x} - {y} = {calculator.Subtract(x, y)}");
            Console.WriteLine($"умножение: {x} * {y} = {calculator.Multiply(x, y)}");

            try
            {
                Console.WriteLine($"деление: {x} / {y} = {calculator.Divide(x, y)}");

                Console.WriteLine($"попытка деления на ноль: {x} / 0 = ?");
                calculator.Divide(x, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- проверка простых чисел ---");
            int[] testNumbers = { 17, 20, 1, 2, 97, 100 };

            foreach (int num in testNumbers)
            {
                Console.WriteLine($"число {num} простое? {calculator.IsPrime(num)}");
            }

            Console.WriteLine("\n--- возведение в степень ---");
            Console.WriteLine($"2 в степени 3 = {calculator.Power(2, 3)}");
            Console.WriteLine($"5 в степени 0 = {calculator.Power(5, 0)}");
            Console.WriteLine($"2 в степени -1 = {calculator.Power(2, -1)}");
            Console.WriteLine($"9 в степени 0.5 = {calculator.Power(9, 0.5)}");

            Console.WriteLine("\n--- факториал ---");
            int[] factNumbers = { 5, 0, 1, 10 };

            foreach (int num in factNumbers)
            {
                try
                {
                    Console.WriteLine($"факториал {num}! = {calculator.Factorial(num)}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ошибка для числа {num}: {ex.Message}");
                }
            }

            try
            {
                Console.WriteLine($"попытка вычислить факториал -3: {calculator.Factorial(-3)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- решение квадратных уравнений ---");

            var equations = new[]
            {
                new { a = 1.0, b = -5.0, c = 6.0, desc = "x² - 5x + 6 = 0 (два корня)" },
                new { a = 1.0, b = 2.0, c = 1.0, desc = "x² + 2x + 1 = 0 (один корень)" },
                new { a = 1.0, b = 0.0, c = 1.0, desc = "x² + 1 = 0 (нет корней)" },
                new { a = 0.0, b = 2.0, c = 4.0, desc = "2x + 4 = 0 (линейное)" },
                new { a = 0.0, b = 0.0, c = 5.0, desc = "5 = 0 (нет решений)" },
                new { a = 0.0, b = 0.0, c = 0.0, desc = "0 = 0 (бесконечно много решений)" }
            };

            foreach (var eq in equations)
            {
                Console.WriteLine($"\n{eq.desc}");
                bool hasRoots = calculator.SolveQuadratic(eq.a, eq.b, eq.c, out double? root1, out double? root2);

                if (hasRoots)
                {
                    if (root1.HasValue && root2.HasValue && Math.Abs(root1.Value - root2.Value) < 1e-10)
                    {
                        Console.WriteLine($"  один корень: x = {root1}");
                    }
                    else if (root1.HasValue && root2.HasValue)
                    {
                        Console.WriteLine($"  два корня: x1 = {root1}, x2 = {root2}");
                    }
                    else if (root1.HasValue)
                    {
                        Console.WriteLine($"  один корень (линейное): x = {root1}");
                    }
                    else
                    {
                        Console.WriteLine("  бесконечно много решений");
                    }
                }
                else
                {
                    Console.WriteLine("  нет действительных корней");
                }
            }

            Console.WriteLine("\n--- работа через интерфейс ---");
            ICalculator calcInterface = new Calculator();
            Console.WriteLine($"сложение через интерфейс: 15 + 7 = {calcInterface.Add(15, 7)}");
            Console.WriteLine($"проверка числа 13 (простое?): {calcInterface.IsPrime(13)}");

            Console.WriteLine("\nнажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}