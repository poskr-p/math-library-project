using Math_Library;

namespace math_library.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ ВСЕХ ВОЗМОЖНОСТЕЙ MATHLIBRARY ===\n");

            var calc = new Calculator();

            // 1. Арифметика
            Console.WriteLine("1. АРИФМЕТИЧЕСКИЕ ОПЕРАЦИИ:");
            double a = 15, b = 4;
            Console.WriteLine($"   {a} + {b} = {calc.Add(a, b)}");
            Console.WriteLine($"   {a} - {b} = {calc.Subtract(a, b)}");
            Console.WriteLine($"   {a} * {b} = {calc.Multiply(a, b)}");

            try
            {
                Console.WriteLine($"   {a} / {b} = {calc.Divide(a, b)}");
                Console.WriteLine($"   попытка деления на ноль: {a} / 0 = ?");
                calc.Divide(a, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"   ошибка: {ex.Message}");
            }

            // 2. Простые числа
            Console.WriteLine("\n2. ПРОВЕРКА ПРОСТЫХ ЧИСЕЛ:");
            int[] primes = { 2, 3, 17, 19, 97, 100 };
            foreach (int num in primes)
            {
                Console.WriteLine($"   число {num} простое? {calc.IsPrime(num)}");
            }

            // 3. Степень
            Console.WriteLine("\n3. ВОЗВЕДЕНИЕ В СТЕПЕНЬ:");
            Console.WriteLine($"   2^3 = {calc.Power(2, 3)}");
            Console.WriteLine($"   5^0 = {calc.Power(5, 0)}");
            Console.WriteLine($"   2^(-1) = {calc.Power(2, -1)}");

            // 4. Факториал
            Console.WriteLine("\n4. ФАКТОРИАЛ:");
            int[] facts = { 0, 1, 5, 10 };
            foreach (int num in facts)
            {
                try
                {
                    Console.WriteLine($"   {num}! = {calc.Factorial(num)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"   ошибка для {num}: {ex.Message}");
                }
            }

            // 5. Квадратные уравнения
            Console.WriteLine("\n5. КВАДРАТНЫЕ УРАВНЕНИЯ:");

            // два корня
            bool hasRoots = calc.SolveQuadratic(1, -5, 6, out double? x1, out double? x2);
            Console.WriteLine($"   x^2 - 5x + 6 = 0: корни = {x1}, {x2}");

            // один корень
            hasRoots = calc.SolveQuadratic(1, 2, 1, out x1, out x2);
            Console.WriteLine($"   x^2 + 2x + 1 = 0: корни = {x1}");

            // нет корней
            hasRoots = calc.SolveQuadratic(1, 0, 1, out x1, out x2);
            Console.WriteLine($"   x^2 + 1 = 0: есть корни? {hasRoots}");

            // линейное
            hasRoots = calc.SolveQuadratic(0, 2, 4, out x1, out x2);
            Console.WriteLine($"   2x + 4 = 0: корень = {x1}");

            Console.WriteLine("\nнажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}