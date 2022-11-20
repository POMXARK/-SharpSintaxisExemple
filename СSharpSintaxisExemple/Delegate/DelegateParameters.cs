
using System.Security.Cryptography.X509Certificates;

namespace СSharpSintaxisExemple.Delegate
{
    internal class DelegateParameters
    {
        /// <summary>
        /// делегат, который принимает параметры и возвращает результат
        /// </summary>
        public static void Exemple()
        {
            Operation operation = Add;      // делегат указывает на метод Add
            int result = operation(4, 5);   // фактически Add(4, 5)
            Console.WriteLine(result);      // 9

            operation = Multiply;           // теперь делегат указывает на метод Multiply
            result = operation(4, 5);       // фактически Multiply(4, 5)
            Console.WriteLine(result);      // 20

            // однострочный метод, возвращает указанный тип int
            //int Add(int x, int y) => x + y; 

            int Add(int x, int y)
            {
                return x + y;
            }

            // однострочный метод, возвращает указанный тип int
            int Multiply(int x, int y) => x * y; // однострочный метод

        }

        /// <summary>
        /// Присвоение ссылки на метод
        /// </summary>
        public static void AssigningMethodReference()
        {
            Operation operation1 = Add;
            int result = operation1(2, 2);   // фактически Add(2, 2)
            Console.WriteLine(result);      // 4

            // присвоение делигату, делигата
            // тоже самое, но больше кода
            Operation operation2 = new Operation(Add); 
            result = operation2(3, 3); // 6
            Console.WriteLine(result);

            // однострочный метод, возвращает указанный тип int
            int Add(int x, int y) => x + y;
        }

        // делегату соответствует любой метод,
        // который возвращает значение типа int
        // и принимает два параметра типа int
        delegate int Operation(int x, int y);
    }
}
