using System;

namespace EngMoneyApp
{
    class EngMoney
    {
        private int pounds;
        private int shillings;
        private int pence;

        // Конструктор
        public EngMoney(int pounds, int shillings, int pence)
        {
            this.pounds = pounds;
            this.shillings = shillings;
            this.pence = pence;

            Normalize();
        }

        // Деструктор
        ~EngMoney()
        {
            Console.WriteLine("Объект EngMoney уничтожен");
        }

        // Свойства
        public int Pounds
        {
            get { return pounds; }
            set { pounds = value; }
        }

        public int Shillings
        {
            get { return shillings; }
            set { shillings = value; }
        }

        public int Pence
        {
            get { return pence; }
            set { pence = value; }
        }

        // Нормализация суммы
        private void Normalize()
        {
            shillings += pence / 12;
            pence %= 12;

            pounds += shillings / 20;
            shillings %= 20;
        }

        // Перевод в пенсы
        public int ToPence()
        {
            return pounds * 240 + shillings * 12 + pence;
        }

        // Сложение
        public EngMoney Add(EngMoney other)
        {
            return new EngMoney(
                0,
                0,
                this.ToPence() + other.ToPence()
            );
        }

        // Вычитание
        public EngMoney Subtract(EngMoney other)
        {
            return new EngMoney(
                0,
                0,
                this.ToPence() - other.ToPence()
            );
        }

        // Умножение
        public EngMoney Multiply(EngMoney other)
        {
            return new EngMoney(
                0,
                0,
                this.ToPence() * other.ToPence()
            );
        }

        // Деление первой суммы на вторую
        public double Divide(EngMoney other)
        {
            if (other.ToPence() == 0)
                throw new DivideByZeroException();

            return (double)this.ToPence() / other.ToPence();
        }

        // Сравнение
        public void Compare(EngMoney other)
        {
            if (this.ToPence() > other.ToPence())
                Console.WriteLine("Первая сумма больше");
            else if (this.ToPence() < other.ToPence())
                Console.WriteLine("Вторая сумма больше");
            else
                Console.WriteLine("Суммы равны");
        }

        public override string ToString()
        {
            return $"{pounds} фунт. {shillings} шилл. {pence} пенс.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите фунты первой суммы: ");
                int p1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите шиллинги: ");
                int s1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите пенсы: ");
                int pe1 = Convert.ToInt32(Console.ReadLine());

                EngMoney money1 = new EngMoney(p1, s1, pe1);

                Console.WriteLine();

                Console.Write("Введите фунты второй суммы: ");
                int p2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите шиллинги: ");
                int s2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите пенсы: ");
                int pe2 = Convert.ToInt32(Console.ReadLine());

                EngMoney money2 = new EngMoney(p2, s2, pe2);

                Console.WriteLine("\nСумма 1: " + money1);
                Console.WriteLine("Сумма 2: " + money2);

                Console.WriteLine("\nСложение:");
                Console.WriteLine(money1.Add(money2));

                Console.WriteLine("\nВычитание:");
                Console.WriteLine(money1.Subtract(money2));

                Console.WriteLine("\nУмножение:");
                Console.WriteLine(money1.Multiply(money2));

                Console.WriteLine("\nДеление первой суммы на вторую:");
                Console.WriteLine(money1.Divide(money2));

                Console.WriteLine("\nСравнение:");
                money1.Compare(money2);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на ноль!");
            }
        }
    }
}

