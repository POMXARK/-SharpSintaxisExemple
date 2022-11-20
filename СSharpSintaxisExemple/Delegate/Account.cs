// https://metanit.com/sharp/tutorial/3.43.php

namespace СSharpSintaxisExemple.Delegate
{
    /// <summary>
    /// Пример плохого сввязанного с рееализацией решения
    /// </summary>
    public class AccountBad
    {
        int sum; // Переменная для хранения суммы

        // через конструктор устанавливается начальная сумма на счете
        public AccountBad(int sum) => this.sum = sum;

        // добавить средства на счет
        public void Add(int sum) => this.sum += sum;

        // взять деньги с счета
        public void Take(int sum)
        {
            // берем деньги, если на счете достаточно средств
            if (this.sum >= sum) this.sum -= sum; // односточное условие

            //if (this.sum >= sum) 
            //{
            //    this.sum -= sum;
            //}

            Console.WriteLine($"Со счета списано {sum} у.е.");
        }
    }

    // Объявляем делегат
    public delegate void AccountHandler(string message);
    public class Account
    {
        int sum;

        // Создаем переменную делегата
        AccountHandler? taken;

        // конструктор
        public Account(int sum) => this.sum = sum;



        /// <summary>
        /// Регистрируем делегат ??? / Делегаты как параметры методов
        /// для передачи делегата в класс. 
        /// метод RegisterHandler, который передается в переменную taken реальное действие
        /// </summary>
        /// <param name="del"></param>
        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }


        // Отмена регистрации делегата
        public void UnregisterHandler(AccountHandler del)
        {
            taken -= del; // удаляем делегат
        }

        // метод
        public void Add(int sum) => this.sum += sum;

        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
            }
        }

    }
}
