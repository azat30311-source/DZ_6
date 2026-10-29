
namespace DZ6_Latypova
{
    /// <summary>
    /// Класс участника аукциона.
    /// </summary>
    public class AuctionParticipant
    {
        private static int _participantCounter = 0;
        private int _participantId;
        private string _name;
        private decimal _balance;
        private bool _isVip;

        public AuctionParticipant()
        {
            _participantId = ++_participantCounter;
            _name = "Аноним";
            _balance = 50000m;
            _isVip = false;
        }

        public AuctionParticipant(string name, decimal balance, bool isVip)
        {
            _participantId = ++_participantCounter;
            Name = name;
            Balance = balance;
            IsVip = isVip;
        }

        public int ParticipantId
        {
            get { return _participantId; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Имя участника не может быть пустым!");
                _name = value;
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0) throw new ArgumentException("Баланс участника не может быть отрицательным!");
                _balance = value;
            }
        }

        public bool IsVip
        {
            get { return _isVip; }
            set { _isVip = value; }
        }

        public void MakeBid(AuctionItem item, decimal amount)
        {
            if (amount > _balance)
                throw new ArgumentException("У вас недостаточно средств на балансе для такой ставки!");

            item.RegisterBid(amount);
            Console.WriteLine($"Участник {_name} сделал ставку {amount} руб. на лот '{item.Title}'.");
        }

        public void TopUpBalance(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма пополнения должна быть больше нуля!");
            Balance += amount;
            Console.WriteLine($"Баланс участника {_name} пополнен на {amount} руб. Текущий баланс: {_balance} руб.");
        }

        public void WithdrawFunds(decimal amount)
        {
            if (amount > _balance) throw new ArgumentException("Нельзя снять сумму больше текущего баланса!");
            Balance -= amount;
            Console.WriteLine($"Со счета участника {_name} списано {amount} руб. Остаток: {_balance} руб.");
        }

        public void PrintParticipantInfo()
        {
            Console.WriteLine($"Участник №{_participantId}: {_name} | Баланс: {_balance} руб. | Статус: {(_isVip ? "VIP" : "Обычный")}");
        }

        public void CheckSolvency(decimal requiredAmount)
        {
            if (_balance >= requiredAmount)
                Console.WriteLine($"Участник {_name} платежеспособен для суммы {requiredAmount} руб.");
            else
                Console.WriteLine($"Участник {_name} НЕ платежеспособен. Требуется пополнение баланса!");
        }
    }
}