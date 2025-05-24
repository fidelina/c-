internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Разделение строки на слова");
            // Console.WriteLine("2 - Перестановка слов в предложении");
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
        Console.Write("Введите предложение: ");
        var input = Console.ReadLine();

        string[] words = SplitText(input);

        Console.WriteLine("\nСлова в предложении:");
        PrintWords(words);
    }

    private static void task2()
    {
        Console.Write("Введите предложение: ");
        var input = Console.ReadLine();

        var reversed = Reverse(input);

        Console.WriteLine("\nПредложение с переставленными словами:");
        Console.WriteLine(reversed);
    }

    private static string[] SplitText(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private static void PrintWords(string[] words)
    {
        foreach (var word in words) Console.WriteLine(word);
    }

    private static string Reverse(string text)
    {
        string[] words = SplitText(text);
        Array.Reverse(words);
        return string.Join(" ", words);
    }
}