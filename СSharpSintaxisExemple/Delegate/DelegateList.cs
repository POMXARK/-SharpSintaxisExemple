

namespace СSharpSintaxisExemple.Delegate
{
    /// <summary>
    /// Очередь делигатов
    /// при вызове делегата все методы из этого списка последовательно вызываются
    /// </summary>
    public static class DelegateList
    {
        delegate void Message();

        static void Hello() => Console.WriteLine("Hello");
        static void HowAreYou() => Console.WriteLine("How are you?");


        static int Add(int x, int y) => x + y;
        static int Subtract(int x, int y) => x - y;
        static int Multiply(int x, int y) => x * y;
        /// <summary>
        /// Добавление методов в делегат.
        /// Делегат может указывать на множество методов,
        /// которые имеют ту же сигнатуру (список аргументов) и возвращаемый тип
        /// </summary>
        public static void QueueDelegate()
        {
            Message message = Hello;
            message += HowAreYou;  // теперь message указывает на два метода
            message();             // вызываются оба метода - Hello и HowAreYou


        }

        /// <summary>
        /// Можем добавить ссылку на один и тот же метод несколько раз,
        /// добавленный метод будет вызываться столько раз, сколько он был добавлен
        /// </summary>
        public static void DoobleDeligate()
        {
             Message message = Hello;
             message += HowAreYou;
             message += Hello;
             message += Hello;
             message();
        }

        /// <summary>
        /// Удалить метод из очереди вызовов делигата,
        /// поиск с конца списка вызова делегата 
        /// и удаляет только первое найденное вхождение
        /// </summary>
        public static void DelUseMethod()
        {
            Message? message = Hello; // ? тип может быть null
            message += HowAreYou;
            message();  // вызываются все методы из message
            message -= HowAreYou;   // удаляем метод HowAreYou
            if (message != null) message(); // вызывается метод Hello
        }

        /// <summary>
        /// Объединение делегатов
        /// </summary>
        public static void MergeDelegate()
        {
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2; // объединяем делегаты
            mes3(); // вызываются все методы из mes1 и mes2
        }

        /// <summary>
        /// Возвращается значение последнего метода из списка вызова
        /// </summary>
        public static void ReturnEnd()
        {
            Operation op = Subtract;
            op += Multiply;
            op += Add;
            Console.WriteLine(op(7, 2));    // Add(7,2) = 9
        }

        /// <summary>
        /// Обобщенные делегаты.
        ///  delegate T Operation<T, K>(K val);
        /// </summary>
        public static void CommonDelegate()
        {
            Operation<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation(5);
            Console.WriteLine(result1);  // 25

            Operation<int, int> doubleOperation = Double;
            int result2 = doubleOperation(5);
            Console.WriteLine(result2);  // 10
        }

        static decimal Square(int n) => n * n;
        static int Double(int n) => n + n;

        // перегрузки делегатов
        delegate T Operation<T, K>(K val);
        delegate int Operation(int x, int y);

        static void DoOperation(int a, int b, Operation op)
        {
            Console.WriteLine(op(a, b));
        }

        /// <summary>
        /// Делегаты как параметры методов
        /// </summary>
        public static void DelegateHowArgumentMethod()
        {
            DoOperation(5, 4, Add);         // 9
            DoOperation(5, 4, Subtract);    // 1
            DoOperation(5, 4, Multiply);    // 20
        }


        static Operation SelectOperation(OperationType opType)
        {
            switch (opType)
            {
                case OperationType.Add: return Add;
                case OperationType.Subtract: return Subtract;
                default: return Multiply;
            }
        }

        enum OperationType
        {
            Add, Subtract, Multiply
        }

        /// <summary>
        /// Возвращение делегатов из метода?
        /// </summary>
        public static void ReternDelegateFromMethod()
        {
            Operation operation = SelectOperation(OperationType.Add);
            Console.WriteLine(operation(10, 4));    // 14

            operation = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation(10, 4));    // 6

            operation = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation(10, 4));    // 40
        }

        /// Другой способ вызова делегата представляет метод Invoke():
        /// Message mes = Hello;
        /// mes.Invoke(); // Hello
        /// Operation op = Add;
        /// int n = op.Invoke(3, 4);
        /// Console.WriteLine(n);   // 7
        /// 

        ///при вызове делегата всегда лучше проверять, не равен ли он null. 
        ///Либо можно использовать метод Invoke и оператор условного null:
        ///Message? mes = null;
        ///mes?.Invoke();        // ошибки нет, делегат просто не вызывается

        /// Operation? op = Add;
        /// op -= Add;          // делегат op пуст
        /// int? n = op?.Invoke(3, 4);   // ошибки нет, делегат просто не вызывается, а n = null

    }
}
