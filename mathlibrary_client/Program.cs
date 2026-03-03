using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math_Library;  


namespace mathlibrary_client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("== демонстрация работы mathlibrary.dll ==\n");

            double x = 10, y = 4;

            // используем статические методы из класса calculator
            Console.WriteLine($"сложение: {x} + {y} = {Calculator.Add(x, y)}");
            Console.WriteLine($"вычитание: {x} - {y} = {Calculator.Subtract(x, y)}");
            Console.WriteLine($"умножение: {x} * {y} = {Calculator.Multiply(x, y)}");

            // деление с обработкой ошибки
            try
            {
                Console.WriteLine($"деление: {x} / {y} = {Calculator.Divide(x, y)}");

                // пробуем разделить на ноль
                Console.WriteLine($"попытка деления на ноль: {x} / 0 = ?");
                Calculator.Divide(x, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }

            // проверка чисел на простоту
            Console.WriteLine("\n--- проверка простых чисел ---");
            int testNumber = 17;
            Console.WriteLine($"число {testNumber} простое? {Calculator.IsPrime(testNumber)}");
            testNumber = 20;
            Console.WriteLine($"число {testNumber} простое? {Calculator.IsPrime(testNumber)}");

            Console.WriteLine("\nнажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
