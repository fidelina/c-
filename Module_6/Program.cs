internal class Program
{
    private const string FilePath = "employees.txt";

    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Вывести список сотрудников");
            Console.WriteLine("2 - Добавить нового сотрудника");
            Console.WriteLine("0 - Выход");
            Console.Write("Введите номер действия: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayEmployees();
                    break;
                case "2":
                    AddEmployee();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    private static void DisplayEmployees()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("Файл не найден. Добавьте хотя бы одного сотрудника.");
            return;
        }

        string[] lines = File.ReadAllLines(FilePath);
        foreach (var line in lines)
        {
            string[] data = line.Split('#');
            Console.WriteLine(
                $"ID: {data[0]}, Дата добавления: {data[1]}, ФИО: {data[2]}, Возраст: {data[3]}, Рост: {data[4]}, Дата рождения: {data[5]}, Место рождения: {data[6]}");
        }
    }

    private static void AddEmployee()
    {
        Console.Write("Введите ФИО: ");
        var fullName = Console.ReadLine();

        Console.Write("Введите возраст: ");
        var age = int.Parse(Console.ReadLine());

        Console.Write("Введите рост (в см): ");
        var height = int.Parse(Console.ReadLine());

        Console.Write("Введите дату рождения (дд.ММ.гггг): ");
        var birthDate = Console.ReadLine();

        Console.Write("Введите место рождения: ");
        var birthPlace = Console.ReadLine();

        var id = File.Exists(FilePath) ? File.ReadAllLines(FilePath).Length + 1 : 1;
        var dateAdded = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

        var newRecord = $"{id}#{dateAdded}#{fullName}#{age}#{height}#{birthDate}#{birthPlace}";

        File.AppendAllText(FilePath, newRecord + Environment.NewLine);
        Console.WriteLine("Сотрудник успешно добавлен!");
    }
}