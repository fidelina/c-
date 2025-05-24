internal class Program
{
    private static void Main()
    {
        var fullName = "Иванов Иван Иванович";
        var age = 25;
        var email = "ivanov@example.com";
        var programmingScore = 85.5;
        var mathScore = 90.0;
        var physicsScore = 78.3;

        Console.WriteLine("Студент: {0}", fullName);
        Console.WriteLine("Возраст: {0}", age);
        Console.WriteLine("Email: {0}", email);
        Console.WriteLine("Баллы по программированию: {0}", programmingScore);
        Console.WriteLine("Баллы по математике: {0}", mathScore);
        Console.WriteLine("Баллы по физике: {0}\n", physicsScore);

        var totalScore = programmingScore + mathScore + physicsScore;
        var averageScore = totalScore / 3;

        Console.WriteLine("Общая сумма баллов: {0}", totalScore);
        Console.WriteLine("Средний балл: {0:F2}\n", averageScore);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}