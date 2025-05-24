namespace Module_7;

internal class Program
{
    private static void Main()
    {
        var repository = new Repository("workers.txt");

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Просмотреть все записи");
            Console.WriteLine("2 - Просмотреть запись по ID");
            Console.WriteLine("3 - Добавить нового сотрудника");
            Console.WriteLine("4 - Удалить сотрудника по ID");
            Console.WriteLine("5 - Получить записи по диапазону дат");
            Console.WriteLine("6 - Сортировать записи по ФИО");
            Console.WriteLine("7 - Сортировать записи по ID");
            Console.WriteLine("0 - Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllWorkers(repository);
                    break;
                case "2":
                    ViewWorkerById(repository);
                    break;
                case "3":
                    AddWorker(repository);
                    break;
                case "4":
                    DeleteWorker(repository);
                    break;
                case "5":
                    GetWorkersByDateRange(repository);
                    break;
                case "6":
                    repository.SortWorkersByFIO();
                    Console.WriteLine("Записи отсортированы по ФИО.");
                    break;
                case "7":
                    repository.SortWorkersByID();
                    Console.WriteLine("Записи отсортированы по ID.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    private static void DisplayAllWorkers(Repository repository)
    {
        var workers = repository.GetAllWorkers();
        foreach (var worker in workers) Console.WriteLine(worker);
    }

    private static void ViewWorkerById(Repository repository)
    {
        Console.Write("Введите ID сотрудника: ");
        var id = int.Parse(Console.ReadLine());
        var worker = repository.GetWorkerById(id);
        if (worker.Id != 0)
            Console.WriteLine(worker);
        else
            Console.WriteLine("Сотрудник с таким ID не найден.");
    }

    private static void AddWorker(Repository repository)
    {
        Console.Write("Введите ФИО: ");
        var fio = Console.ReadLine();
        Console.Write("Введите возраст: ");
        var age = int.Parse(Console.ReadLine());
        Console.Write("Введите рост: ");
        var height = int.Parse(Console.ReadLine());
        Console.Write("Введите дату рождения (дд.ММ.гггг): ");
        var birthDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите место рождения: ");
        var birthPlace = Console.ReadLine();

        var newWorker = new Worker(
            0, DateTime.Now, fio, age, height, birthDate, birthPlace
        );
        repository.AddWorker(newWorker);
        Console.WriteLine("Сотрудник добавлен.");
    }

    private static void DeleteWorker(Repository repository)
    {
        Console.Write("Введите ID сотрудника для удаления: ");
        var id = int.Parse(Console.ReadLine());
        repository.DeleteWorker(id);
        Console.WriteLine("Сотрудник удален.");
    }

    private static void GetWorkersByDateRange(Repository repository)
    {
        Console.Write("Введите дату начала (дд.ММ.гггг): ");
        var dateFrom = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите дату конца (дд.ММ.гггг): ");
        var dateTo = DateTime.Parse(Console.ReadLine());

        var workers = repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
        foreach (var worker in workers) Console.WriteLine(worker);
    }
}