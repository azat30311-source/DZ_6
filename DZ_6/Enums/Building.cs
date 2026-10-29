

namespace DZ6_Tum
{
    public class Building
    {
        private static int _lastBuildingNumber = 0;
        private int _id;
        private double _height;
        private int _floors;
        private int _apartmentsCount;
        private int _entrancesCount;

        /// <summary>
        /// Конструкторы
        /// </summary>
        
        public Building()
        {
            _id = GenerateBuildingId();
        }

        public Building(double height, int floors, int apartmentsCount, int entrancesCount)
        {
            _id = GenerateBuildingId();
            Height = height;
            Floors = floors;
            ApartmentsCount = apartmentsCount;
            EntrancesCount = entrancesCount;
        }

        /// <summary>
        /// Корреткный вывод данных
        /// </summary>
        /// <returns></returns>

        private static int GenerateBuildingId()
        {
            _lastBuildingNumber++;
            return _lastBuildingNumber;
        }

        public int Id
        {
            get { return _id; }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0) throw new ArgumentException("Высота здания должна быть больше нуля!");
                _height = value;
            }
        }

        public int Floors
        {
            get { return _floors; }
            set
            {
                if (value <= 0) throw new ArgumentException("Количество этажей должно быть больше нуля!");
                _floors = value;
            }
        }

        public int ApartmentsCount
        {
            get { return _apartmentsCount; }
            set
            {
                if (value < 0) throw new ArgumentException("Количество квартир не может быть отрицательным!");
                _apartmentsCount = value;
            }
        }

        public int EntrancesCount
        {
            get { return _entrancesCount; }
            set
            {
                if (value <= 0) throw new ArgumentException("Количество подъездов должно быть больше нуля!");
                _entrancesCount = value;
            }
        }
        /// <summary>
        /// Методы
        /// </summary>

        public double GetFloorHeight()
        {
            if (_floors == 0) return 0;
            return _height / _floors;
        }

        public int GetApartmentsPerEntrance()
        {
            if (_entrancesCount == 0) return 0;
            return _apartmentsCount / _entrancesCount;
        }

        public int GetApartmentsPerFloor()
        {
            if (_floors == 0) return 0;
            return _apartmentsCount / _floors;
        }

        public void PrintBuildingInfo()
        {
            Console.WriteLine($"    Здание №{_id}    ");
            Console.WriteLine($"Высота: {_height} м");
            Console.WriteLine($"Этажность: {_floors}");
            Console.WriteLine($"Всего квартир: {_apartmentsCount}");
            Console.WriteLine($"Количество подъездов: {_entrancesCount}");
            Console.WriteLine($"Высота одного этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир в одном подъезде: {GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на одном этаже: {GetApartmentsPerFloor()}");
            Console.WriteLine();
        }
    }
}
