using System.Xml.Linq;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Работа с листом");
            Console.WriteLine("2 - Телефонная книга");
            Console.WriteLine("3 - Проверка повторов");
            Console.WriteLine("4 - Записная книжка");
            Console.WriteLine("0 - Выход");
            Console.Write("Введите номер действия: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var numbers = GenerateRandomNumbers(100, 0, 100);
                    PrintList(numbers);
                    RemoveNumbersInRange(numbers, 25, 50);
                    PrintList(numbers);
                    break;
                case "2":
                    PhoneBook();
                    break;
                case "3":
                    CheckDuplicates();
                    break;
                case "4":
                    CreateXmlContact();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }


    private static List<int> GenerateRandomNumbers(int count, int minValue, int maxValue)
    {
        var rand = new Random();
        var numbers = new List<int>();
        for (var i = 0; i < count; i++) numbers.Add(rand.Next(minValue, maxValue + 1));

        return numbers;
    }

    private static void PrintList(List<int> numbers)
    {
        foreach (var number in numbers) Console.Write(number + " ");

        Console.WriteLine();
    }

    private static void RemoveNumbersInRange(List<int> numbers, int min, int max)
    {
        numbers.RemoveAll(num => num > min && num < max);
    }

    private static void PhoneBook()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        while (true)
        {
            Console.Write("Введите номер телефона (или пустую строку для завершения): ");
            var phone = Console.ReadLine();
            if (string.IsNullOrEmpty(phone)) break;

            Console.Write("Введите ФИО владельца: ");
            var fio = Console.ReadLine();

            if (phoneBook.ContainsKey(phone))
            {
                Console.WriteLine("Этот номер уже зарегистрирован.");
            }
            else
            {
                phoneBook[phone] = fio;
                Console.WriteLine("Номер добавлен.");
            }
        }

        Console.Write("Введите номер телефона для поиска: ");
        var searchPhone = Console.ReadLine();
        if (phoneBook.TryGetValue(searchPhone, out var owner))
            Console.WriteLine($"Владелец номера {searchPhone}: {owner}");
        else
            Console.WriteLine("Номер не найден.");
    }


    private static void CheckDuplicates()
    {
        var numbersSet = new HashSet<int>();
        while (true)
        {
            Console.Write("Введите число (или пустую строку для завершения): ");
            var numStr = Console.ReadLine();
            if (string.IsNullOrEmpty(numStr)) break;
            var number = int.Parse(numStr);

            if (numbersSet.Contains(number))
            {
                Console.WriteLine("Это число уже было введено.");
            }
            else
            {
                numbersSet.Add(number);
                Console.WriteLine("Число успешно сохранено.");
            }
        }
    }

    private static void CreateXmlContact()
    {
        Console.Write("Введите ФИО: ");
        var name = Console.ReadLine();

        Console.Write("Введите улицу: ");
        var street = Console.ReadLine();

        Console.Write("Введите номер дома: ");
        var houseNumber = Console.ReadLine();

        Console.Write("Введите номер квартиры: ");
        var flatNumber = Console.ReadLine();

        Console.Write("Введите мобильный телефон: ");
        var mobilePhone = Console.ReadLine();

        Console.Write("Введите домашний телефон: ");
        var flatPhone = Console.ReadLine();

        var personElement = new XElement("Person",
            new XAttribute("name", name),
            new XElement("Address",
                new XElement("Street", street),
                new XElement("HouseNumber", houseNumber),
                new XElement("FlatNumber", flatNumber)
            ),
            new XElement("Phones",
                new XElement("MobilePhone", mobilePhone),
                new XElement("FlatPhone", flatPhone)
            )
        );

        var filePath = "contact.xml";
        personElement.Save(filePath);

        Console.WriteLine($"Информация сохранена в файл {filePath}");
    }
}