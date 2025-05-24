internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Проверка чётного/нечётного числа");
            Console.WriteLine("2 - Подсчёт суммы карт в игре '21'");
            Console.WriteLine("3 - Проверка числа на простоту");
            Console.WriteLine("4 - Поиск наименьшего числа в последовательности");
            Console.WriteLine("5 - Игра 'Угадай число'");
            Console.WriteLine("0 - Выход");
            Console.Write("Введите номер задания: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    task1();
                    break;
                case "2":
                    task2();
                    break;
                case "3":
                    task3();
                    break;
                case "4":
                    task4();
                    break;
                case "5":
                    task5();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    private static void task1()
    {
        Console.Write("Введите целое число: ");
        var number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
            Console.WriteLine("Число чётное.");
        else
            Console.WriteLine("Число нечётное.");
    }

    private static void task2()
    {
        Console.Write("Сколько у вас карт на руках? ");
        var cardCount = int.Parse(Console.ReadLine());

        var sum = 0;

        for (var i = 0; i < cardCount; i++)
        {
            Console.Write("Введите номинал карты (2-10 или J, Q, K, T): ");
            var input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "J":
                case "Q":
                case "K":
                case "T":
                    sum += 10;
                    break;
                default:
                    sum += int.Parse(input);
                    break;
            }
        }

        Console.WriteLine($"Сумма карт: {sum}");
    }

    private static void task3()
    {
        Console.Write("Введите число: ");
        var number = int.Parse(Console.ReadLine());

        if (number < 2)
        {
            Console.WriteLine("Число не является простым.");
            return;
        }

        var isPrime = true;
        for (var i = 2; i * i <= number; i++)
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }

        if (isPrime)
            Console.WriteLine("Число является простым.");
        else
            Console.WriteLine("Число не является простым.");
    }

    private static void task4()
    {
        Console.Write("Введите длину последовательности: ");
        var length = int.Parse(Console.ReadLine());

        if (length <= 0)
        {
            Console.WriteLine("Последовательность должна содержать хотя бы одно число.");
            return;
        }

        var min = int.MaxValue;

        for (var i = 0; i < length; i++)
        {
            Console.Write("Введите число: ");
            var number = int.Parse(Console.ReadLine());

            if (number < min)
                min = number;
        }

        Console.WriteLine($"Наименьшее число: {min}");
    }

    private static void task5()
    {
        Console.Write("Введите максимальное число диапазона: ");
        var maxNumber = int.Parse(Console.ReadLine());

        var random = new Random();
        var secretNumber = random.Next(0, maxNumber + 1);

        while (true)
        {
            Console.Write("Угадайте число (или нажмите Enter для выхода): ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"Вы вышли из игры. Загаданное число: {secretNumber}");
                break;
            }

            var guess = int.Parse(input);

            if (guess < secretNumber)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
            else
            {
                Console.WriteLine("Поздравляю! Вы угадали число!");
                break;
            }
        }
    }
}