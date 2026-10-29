
namespace DZ6_Latypova
{
    /// <summary>
    /// Класс лота-картины.
    /// </summary>
    public class Painting : AuctionItem
    {
        private string _artist;
        private int _year;
        private string _canvasType;
        private bool _isFramed;

        public Painting() : base()
        {
            _artist = "Неизвестный художник";
            _year = 2023;
            _canvasType = "Холст";
            _isFramed = false;
        }

        public Painting(string title, decimal startPrice, string artist, int year, string canvasType, bool isFramed)
            : base(title, startPrice)
        {
            Artist = artist;
            Year = year;
            CanvasType = canvasType;
            IsFramed = isFramed;
        }

        public string Artist
        {
            get { return _artist; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Имя художника не может быть пустым!");
                _artist = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value > 2026 || value < 1000) throw new ArgumentException("Некорректный год создания картины!");
                _year = value;
            }
        }

        public string CanvasType
        {
            get { return _canvasType; }
            set { _canvasType = value; }
        }

        public bool IsFramed
        {
            get { return _isFramed; }
            set { _isFramed = value; }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"[Картина] Художник: {_artist}, Год: {_year}, Основа: {_canvasType}, Рама: {(_isFramed ? "Есть" : "Нет")}");
        }

        public override decimal CalculateTax()
        {
            return CurrentBid * 0.07m;
        }

        public override string GetInfoString()
        {
            return $"Картина '{Title}' работы {_artist} ({_year} г.)";
        }

        public void VerifyAuthenticity()
        {
            Console.WriteLine($"Экспертиза картины '{Title}': Подлинность подтверждена сертификатом галереи.");
        }

        public void ApplyGalleryDiscount(decimal percent)
        {
            if (percent < 0 || percent > 50) throw new ArgumentException("Недопустимый процент скидки!");
            StartPrice -= StartPrice * (percent / 100);
            if (CurrentBid < StartPrice) CurrentBid = StartPrice;
            Console.WriteLine($"Применена скидка {percent}%. Новая стартовая цена: {StartPrice} руб.");
        }
    }
}
