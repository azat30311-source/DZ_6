
namespace DZ6_Latypova
{
    class Program
    {
        #region Методы
        /// <summary>
        /// Методы
        /// </summary>
        static Painting CreatePainting()
        {
            Console.Write("Введите название картины: ");
            string title = Console.ReadLine();
            Console.Write("Введите стартовую цену (руб.): ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Введите имя художника: ");
            string artist = Console.ReadLine();
            Console.Write("Введите год создания: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Введите тип холста: ");
            string canvas = Console.ReadLine();
            Console.Write("Есть ли рама? (да/нет): ");
            bool isFramed = Console.ReadLine()?.Trim().ToLower() == "да";

            return new Painting(title, price, artist, year, canvas, isFramed);
        }

        static Sculpture CreateSculpture()
        {
            Console.Write("Введите название скульптуры: ");
            string title = Console.ReadLine();
            Console.Write("Введите стартовую цену (руб.): ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Введите материал: ");
            string material = Console.ReadLine();
            Console.Write("Введите вес (кг): ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Введите имя скульптора: ");
            string sculptor = Console.ReadLine();
            Console.Write("Полая внутри? (да/нет): ");
            bool isHollow = Console.ReadLine()?.Trim().ToLower() == "да";

            return new Sculpture(title, price, material, weight, sculptor, isHollow);
        }
        #endregion
        #region точка входа выполнения задачи
        static void Main()
        {
            Console.WriteLine(" ЗАДАЧА: АУКЦИОН ");

            try
            {
                Console.WriteLine(" РЕГИСТРАЦИЯ УЧАСТНИКА АУКЦИОНА ");
                Console.Write("Введите ваше имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите стартовый баланс участника (руб.): ");
                decimal balance = decimal.Parse(Console.ReadLine());

                Console.Write("Являетесь ли вы VIP-участником? (введите 'да' или 'нет'): ");
                bool isVip = Console.ReadLine()?.Trim().ToLower() switch
                {
                    "да" => true,
                    "нет" => false,
                    _ => throw new ArgumentException("Неверный ввод статуса VIP!")
                };

                AuctionParticipant participant = new AuctionParticipant(name, balance, isVip);
                Console.WriteLine();
                participant.PrintParticipantInfo();
                Console.WriteLine();

                bool continueAuction = true;
                while (continueAuction)
                {
                    Console.WriteLine("СОЗДАНИЕ И ВЫСТАВЛЕНИЕ НОВОГО ЛОТА");
                    Console.Write("Введите тип лота ('картина' или 'скульптура'): ");
                    string lotType = Console.ReadLine()?.Trim().ToLower();

                    AuctionItem customItem = lotType switch
                    {
                        "картина" => CreatePainting(),
                        "скульптура" => CreateSculpture(),
                        _ => throw new ArgumentException("Неверный тип лота! Нужно ввести 'картина' или 'скульптура'.")
                    };

                    Console.WriteLine("Лот успешно создан и выставлен на аукцион!");
                    customItem.DisplayInfo();
                    Console.WriteLine($"Расчет налога для этого лота: {customItem.CalculateTax()} руб.");

                    // Торги по этому лоту
                    Console.WriteLine("ТОРГИ ПО ЛОТУ");
                    Console.Write($"Введите сумму вашей ставки для лота '{customItem.Title}': ");
                    decimal bidAmount = decimal.Parse(Console.ReadLine());

                    participant.MakeBid(customItem, bidAmount);

                    Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ ЛОТА");
                    customItem.DisplayInfo();

                    Console.WriteLine();
                    participant.PrintParticipantInfo();

                    Console.Write("Хотите пополнить или снять средства с баланса? (введите 'пополнить', 'снять' или 'нет'): ");
                    string balanceAction = Console.ReadLine()?.Trim().ToLower();
                    if (balanceAction == "пополнить")
                    {
                        Console.Write("Введите сумму для пополнения (руб.): ");
                        decimal topUpAmount = decimal.Parse(Console.ReadLine());
                        participant.TopUpBalance(topUpAmount);
                    }
                    else if (balanceAction == "снять")
                    {
                        Console.Write("Введите сумму для снятия (руб.): ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        participant.WithdrawFunds(withdrawAmount);
                    }
                    else if (balanceAction != "нет")
                    {
                        Console.WriteLine("Некорректный ввод!");
                    }

                    Console.Write("Хотите выставить еще один лот? (введите 'да' или 'нет'): ");
                    string answer = Console.ReadLine()?.Trim().ToLower();
                    if (answer != "да")
                    {
                        continueAuction = false;
                        Console.WriteLine("Аукцион завершен. Спасибо за участие!");
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели не числа!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion   
    }
}