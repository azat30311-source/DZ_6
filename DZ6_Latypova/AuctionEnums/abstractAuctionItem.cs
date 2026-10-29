
namespace DZ6_Latypova
{
    /// <summary>
    /// Абстрактный базовый класс, представляющий лот на аукционе.
    /// Содержит общие свойства и методы для всех видов лотов.
    /// </summary>
    public abstract class AuctionItem
    {
        private static int _counter = 0;
        protected int _id;
        protected string _title;
        protected decimal _startPrice;
        protected decimal _currentBid;

        public AuctionItem()
        {
            _id = ++_counter;
            _title = "Неизвестный лот";
            _startPrice = 1000m;
            _currentBid = _startPrice;
        }

        public AuctionItem(string title, decimal startPrice)
        {
            _id = ++_counter;
            Title = title;
            StartPrice = startPrice;
            _currentBid = _startPrice;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название лота не может быть пустым!");
                _title = value;
            }
        }

        public decimal StartPrice
        {
            get { return _startPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стартовая цена не может быть отрицательной!");
                _startPrice = value;
            }
        }

        public decimal CurrentBid
        {
            get { return _currentBid; }
            set
            {
                if (value < _startPrice)
                    throw new ArgumentException("Текущая ставка не может быть ниже стартовой цены!");
                _currentBid = value;
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Лот №{_id}: «{_title}», Стартовая цена: {_startPrice} руб., Текущая ставка: {_currentBid} руб.");
        }

        public virtual decimal CalculateTax()
        {
            return _currentBid * 0.05m;
        }

        public virtual void RegisterBid(decimal amount)
        {
            if (amount <= _currentBid)
                throw new ArgumentException("Новая ставка должна быть выше текущей!");
            CurrentBid = amount;
            Console.WriteLine($"Ставка {amount} руб. успешно принята для лота '{_title}'!");
        }

        public void ResetItem()
        {
            _currentBid = _startPrice;
            Console.WriteLine($"Лот '{_title}' сброшен к стартовой цене.");
        }

        public abstract string GetInfoString();
    }
}