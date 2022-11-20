namespace СSharpSintaxisExemple.Delegate
{
    /// <summary>
    /// Примеры синтаксического сахара
    /// </summary>
    public static class Exemples
    {
        /// <summary>
        /// Простой способ использования делегатов
        /// </summary>
        public static void SimpleDelegate()
        {
            //Делегаты представляют такие объекты, которые указывают на методы.
            //То есть делегаты - это указатели на методы и с помощью делегатов мы можем вызвать данные методы.
            // также принимаются модификаторы ref, in и out

            Message mes;            // 2. Создаем переменную делегата
            mes = Hello;            // 3. Присваиваем этой переменной адрес метода
            mes();                  // 4. Вызываем метод (вызовется Hello)

            // Данный метод имеет тот же возвращаемый тип и тот же набор параметров что и у  delegate void Message()
            // однострочный метод, возвращает указанный тип void
            void Hello() => Console.WriteLine("Hello METANIT.COM"); 

        }

        public static void SimpleDelegateNotSugger()
        {
            // void HelloNotSugger() => Console.WriteLine("HelloNotSugger");
            void HelloNotSugger()
            {
                Console.WriteLine("HelloNotSugger");
            }

            Message mes;            // 2. Создаем переменную делегата
            mes = HelloNotSugger;   // 3. Присваиваем этой переменной адрес метода
            mes();                  // 4. Вызываем метод
        }
    }
}
