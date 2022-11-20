using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СSharpSintaxisExemple.Delegate;

namespace СSharpSintaxisExemple
{/// <summary>
/// Лямбда-выражения
/// (список_параметров) => выражение
/// </summary>
    internal class LambdaExpressions
    {
        public static void Exemple()
        {
            Message hello = () =>
            {
                Console.Write("Hello ");
                Console.WriteLine("World");
            };
            hello();       // Hello World
        }

        public static void Exemple2()
        {
            var hello = () => Console.WriteLine("Hello");
            hello();       // Hello
            hello();       // Hello
            hello();       // Hello
        }

        public static void Exemple3()
        {
            Operation sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");
            sum(1, 2);       // 1 + 2 = 3
            sum(22, 14);    // 22 + 14 = 36
        }

        public static void Exemple4()
        {
            PrintHandler print = message => Console.WriteLine(message);
            print("Hello");         // Hello
            print("Welcome");       // Welcome
        }

        /// <summary>
        /// Возвращение результата
        /// </summary>
        public static void Exemple5()
        {
            var sum = (int x, int y) => x + y;
            int sumResult = sum(4, 5);                  // 9
            Console.WriteLine(sumResult);               // 9

            var multiply = (int x, int y) => x * y;
            int multiplyResult = multiply(4, 5);        // 20
            Console.WriteLine(multiplyResult);          // 20
        }

        public static void Exemple6()
        {
            var subtract = (int x, int y) =>
            {
                if (x > y) return x - y;
                else return y - x;
            };
            int result1 = subtract(10, 6);  // 4 
            Console.WriteLine(result1);     // 4

            int result2 = subtract(-10, 6);  // 16
            Console.WriteLine(result2);      // 16
        }

        /// <summary>
        /// Добавление и удаление действий в лямбда-выражении
        /// </summary>
        public static void Exemple7()
        {
            var hello = () => Console.WriteLine("METANIT.COM");

            var message = () => Console.Write("Hello ");
            message += () => Console.WriteLine("World"); // добавляем анонимное лямбда-выражение
            message += hello;   // добавляем лямбда-выражение из переменной hello
            message += Print;   // добавляем метод

            message();
            Console.WriteLine("--------------"); // для разделения вывода

            message -= Print;   // удаляем метод
            message -= hello;   // удаляем лямбда-выражение из переменной hello

            message?.Invoke();  // на случай, если в message больше нет действий

            void Print() => Console.WriteLine("Welcome to C#");
        }

        /// <summary>
        /// Лямбда-выражение как аргумент метода
        /// </summary>
        public static void Exemple8()
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // найдем сумму чисел больше 5
            int result1 = Sum(integers, x => x > 5);
            Console.WriteLine(result1); // 30

            // найдем сумму четных чисел
            int result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine(result2);  //20

            int Sum(int[] numbers, IsEqual func)
            {
                int result = 0;
                foreach (int i in numbers)
                {
                    if (func(i))
                        result += i;
                }
                return result;
            }
        }

        delegate bool IsEqual(int x);
        delegate void Operation(int x, int y);
        delegate void PrintHandler(string message);
    }
}

