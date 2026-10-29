
namespace DZ6_Tum
{
    class Program
    {
        #region tasks
        static void task1()
        {
            Console.WriteLine("\t Упражнение 7.1-7.3 (Банковский счет) \t\n");

            try
            {
                
                Console.Write("Введите количество денег на счете: ");
                decimal balance = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Выберите тип счета.");
                Console.WriteLine("Текущий (Current)");
                Console.WriteLine("Сберегательный (Savings)");
                Console.Write("Введите тип счета: ");
                AccountType accountType = Console.ReadLine().Trim().ToLower() switch
                {
                    "current" => AccountType.Current,
                    "savings" => AccountType.Savings,
                    _ => throw new ArgumentException("Неверно введен тип счёта")
                };


                BankAccount myAccount = new BankAccount(balance, accountType);
                Console.WriteLine("\n--- Информация о созданном счете ---");
                myAccount.PrintAccountInfo();

                Console.Write("Введите сумму для пополнения: ");
                decimal depositAmount = decimal.Parse(Console.ReadLine());

                myAccount.Deposit(depositAmount);
                Console.WriteLine("Счет успешно пополнен!");
                myAccount.PrintAccountInfo();

                Console.Write("Введите сумму для снятия: ");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                myAccount.Withdraw(withdrawAmount);
                Console.WriteLine("Средства успешно списаны!");
                myAccount.PrintAccountInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Нужно было ввести число, а не текст!");
            }
        }
        static void task2()
        {
            Console.WriteLine("\t Домашнее задание 7.1 (Здания) \t \n");
            Console.WriteLine("Введите параметры для первого здания.");

            Console.Write("Введите высоту здания (в метрах): ");
            double height1 = double.Parse(Console.ReadLine());

            Console.Write("Введите количество этажей: ");
            int floors1 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество квартир: ");
            int apartments1 = int.Parse(Console.ReadLine());

            Console.Write("Введите количество подъездов: ");
            int entrances1 = int.Parse(Console.ReadLine());

            Building building1 = new Building(height1, floors1, apartments1, entrances1);

            Console.WriteLine("Введите параметры для второго здания.");

            Building building2 = new Building();

            Console.Write("Введите высоту здания (в метрах): ");
            building2.Height = double.Parse(Console.ReadLine());

            Console.Write("Введите количество этажей: ");
            building2.Floors = int.Parse(Console.ReadLine());

            Console.Write("Введите количество квартир: ");
            building2.ApartmentsCount = int.Parse(Console.ReadLine());

            Console.Write("Введите количество подъездов: ");
            building2.EntrancesCount = int.Parse(Console.ReadLine());

            building1.PrintBuildingInfo();
            building2.PrintBuildingInfo();
        }
        #endregion
        #region main
        static void Main()
        {
            task1();
            task2();
            Console.ReadKey();
        }
        #endregion
    }
}