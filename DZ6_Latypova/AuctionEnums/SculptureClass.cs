
namespace DZ6_Latypova
{
    /// <summary>
    /// Класс лота-скульптуры.
    /// </summary>
    public class Sculpture : AuctionItem
    {
        private string _material;
        private double _weight;
        private string _sculptor;
        private bool _isHollow;

        public Sculpture() : base()
        {
            _material = "Бронза";
            _weight = 10.5;
            _sculptor = "Неизвестный скульптор";
            _isHollow = false;
        }

        public Sculpture(string title, decimal startPrice, string material, double weight, string sculptor, bool isHollow)
            : base(title, startPrice)
        {
            Material = material;
            Weight = weight;
            Sculptor = sculptor;
            IsHollow = isHollow;
        }

        public string Material
        {
            get { return _material; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Материал не может быть пустым!");
                _material = value;
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0) throw new ArgumentException("Вес скульптуры должен быть больше нуля!");
                _weight = value;
            }
        }

        public string Sculptor
        {
            get { return _sculptor; }
            set { _sculptor = value; }
        }

        public bool IsHollow
        {
            get { return _isHollow; }
            set { _isHollow = value; }
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"[Скульптура] Скульптор: {_sculptor}, Материал: {_material}, Вес: {_weight} кг, Полая: {(_isHollow ? "Да" : "Нет")}");
        }

        public override decimal CalculateTax()
        {
            return CurrentBid * 0.06m;
        }

        public override string GetInfoString()
        {
            return $"Скульптура '{Title}' из материала {_material}";
        }

        public void CalculateShippingCost()
        {
            decimal cost = (decimal)(_weight * 150);
            Console.WriteLine($"Расчет доставки для скульптуры '{Title}': {cost} руб.");
        }

        public void CheckFragility()
        {
            if (_weight > 20 || !_isHollow)
                Console.WriteLine($"Скульптура '{Title}' требует усиленной бронированной упаковки при перевозке.");
            else
                Console.WriteLine($"Скульптура '{Title}' стандартной хрупкости.");
        }
    }
}
