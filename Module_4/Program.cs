internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Случайная матрица");
            Console.WriteLine("2 - Сложение матриц");
            Console.WriteLine("3 - Игра 'Жизнь'");
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
        Console.Write("Введите количество строк: ");
        var rows = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        var cols = int.Parse(Console.ReadLine());

        var matrix = new int[rows, cols];
        var rand = new Random();
        var sum = 0;

        Console.WriteLine("\nСлучайная матрица:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(10, 100);
                sum += matrix[i, j];
                Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Сумма всех элементов: {sum}");
    }

    private static void task2()
    {
        Console.Write("Введите количество строк: ");
        var rows = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        var cols = int.Parse(Console.ReadLine());

        var matrixA = new int[rows, cols];
        var matrixB = new int[rows, cols];
        var matrixC = new int[rows, cols];
        var rand = new Random();

        Console.WriteLine("\nМатрица A:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                matrixA[i, j] = rand.Next(1, 10);
                Console.Write(matrixA[i, j] + "\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine("\nМатрица B:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                matrixB[i, j] = rand.Next(1, 10);
                Console.Write(matrixB[i, j] + "\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine("\nСумма матриц:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                Console.Write(matrixC[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    private static void task3()
    {
        Console.Write("Введите ширину поля: ");
        var width = int.Parse(Console.ReadLine());
        Console.Write("Введите высоту поля: ");
        var height = int.Parse(Console.ReadLine());

        var field = new bool[height, width];
        var rand = new Random();

        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
            field[i, j] = rand.Next(2) == 0;

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            DrawField(field);
            field = GetNextGeneration(field);
            Thread.Sleep(300);
        }
    }

    private static void DrawField(bool[,] field)
    {
        for (var i = 0; i < field.GetLength(0); i++)
        {
            for (var j = 0; j < field.GetLength(1); j++) Console.Write(field[i, j] ? "█" : " ");
            Console.WriteLine();
        }
    }

    private static bool[,] GetNextGeneration(bool[,] field)
    {
        var rows = field.GetLength(0);
        var cols = field.GetLength(1);
        var newField = new bool[rows, cols];

        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            var neighbors = CountNeighbors(field, i, j);
            if (field[i, j])
                newField[i, j] = neighbors == 2 || neighbors == 3;
            else
                newField[i, j] = neighbors == 3;
        }

        return newField;
    }

    private static int CountNeighbors(bool[,] field, int x, int y)
    {
        var count = 0;
        var rows = field.GetLength(0);
        var cols = field.GetLength(1);

        for (var i = -1; i <= 1; i++)
        for (var j = -1; j <= 1; j++)
        {
            if (i == 0 && j == 0)
                continue;

            var newX = x + i;
            var newY = y + j;

            if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && field[newX, newY])
                count++;
        }

        return count;
    }
}