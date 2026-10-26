
namespace DZ6_Tum
{
    class Program
    {
        #region tasks
        static void task1()
        {
            Console.WriteLine("\t Упражнение 7.1-7.3 \t");
            Console.WriteLine("Создание класса банковского счета.\n");

            BankAccount myAccount = new BankAccount();

            myAccount.Balance = 676767.6767m;
            myAccount.AccountTypeProperty = AccountType.Savings;

            myAccount.PrintAccountInfo();
            BankAccount account1 = new BankAccount(5252m, AccountType.Current);
            BankAccount account2 = new BankAccount(9999m, AccountType.Savings);
            BankAccount account3 = new BankAccount();

            account3.Deposit(6767m);
            account3.Withdraw(5252m);

            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            account3.PrintAccountInfo();
            Console.ReadKey();

        }
        static void task2()
        {
            Console.WriteLine("\t Домашнее задание 7.1 (Здания) \t \n");

            Building building1 = new Building(45.5, 14, 112, 2);

            Building building2 = new Building();

            building2.Height = 30.0;
            building2.Floors = 9;
            building2.ApartmentsCount = 36;
            building2.EntrancesCount = 1;

            building1.PrintBuildingInfo();
            building2.PrintBuildingInfo();

            Console.ReadKey();
        }
        #endregion
        #region main
        static void Main()
        {
            task1();
            task2();
        }
        #endregion
    }
}