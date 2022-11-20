
namespace СSharpSintaxisExemple.Delegate
{
    // делегат определяется в конце кода, внутри класса и вне класса
    // если делегат определен вне класса, то он дейсвует на все классы обьявленные
    // в пространстве имен namespace
    delegate void Message(); // 1. Объявляем делегат

    public class ExepmpleConnectDelegate
    {
        /// <summary>
        /// Пример использования делегата с методами внешнего класса
        /// </summary>
        public static void ConnectDelegate()
        {
            //Message message1;
            //message1 = Welcome.Print;

            // 2. Создаем переменную делегата
            // и сразу присваиваем этой переменной адрес метода внешнего класса
            Message message1 = Welcome.Print;

            // 2. Создаем переменную делегата
            // и сразу присваиваем этой переменной адрес метода внешнего класса
            Message message2 = new Hello().Display; 

            message1(); // Welcome  
            message2(); // Привет  
        }
    }

    /// <summary>
    /// Пример вызова статического класса
    /// </summary>
    public static class Welcome
    {
        // однострочный метод, возвращает указанный тип void
        public static void Print() => Console.WriteLine("Welcome");

        //public static void Print()
        //{
        //    Console.WriteLine("Welcome");
        //}
    }

    /// <summary>
    /// Пример с экземпляром класса
    /// </summary>
    public class Hello
    {
        // однострочный метод, возвращает указанный тип void
        public void Display() => Console.WriteLine("Привет");

        //public void Display()
        //{
        //    Console.WriteLine("Привет");
        //}
    }
}
