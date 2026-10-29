
namespace DZ6_Tum
{
    public enum AccountType
    {
        Current,
        Savings
    }

    public class BankAccount
    {
        private static int count = 0;
        private int _accountNumber;
        private decimal _balance;
        private AccountType _accountType;

        public BankAccount()
        {
            _accountNumber = GenerateAccountID();
        }

        public BankAccount(decimal balance, AccountType accountType)
        {
            _accountNumber = GenerateAccountID();
            Balance = balance;
            _accountType = accountType;
        }

        private static int GenerateAccountID()
        {
            count++;
            return count;
        }

        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс счета не может быть отрицательным!");
                }
                _balance = value;
            }
        }

        public AccountType AccountTypeProperty
        {
            get { return _accountType; }
            set { _accountType = value; }
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Пополняемая сумма должны быть положительна!");
            }
            _balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (_balance < amount)
            {
                throw new ArgumentException("Недостаточно средтсв!");
            }
            _balance -= amount;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {_accountNumber}");
            Console.WriteLine($"Баланс счета: {_balance} руб.");
            Console.WriteLine($"Тип счета: {_accountType}");
            Console.WriteLine();
        }
    }
}
