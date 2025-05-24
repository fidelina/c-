namespace StringManipulationApp;

public class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Метод для разделения строки на слова
    private void SplitWordsButton_Click(object sender, RoutedEventArgs e)
    {
        // Получаем строку из TextBox
        string input = InputTextBox.Text;

        // Разделяем строку на слова по пробелам
        var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Очищаем ListBox
        WordsListBox.Items.Clear();

        // Добавляем каждое слово в ListBox
        foreach (var word in words) WordsListBox.Items.Add(word);
    }

    // Метод для перестановки слов в строке
    private void ReverseWordsButton_Click(object sender, RoutedEventArgs e)
    {
        // Получаем строку из TextBox
        string input = ReversedTextBox.Text;

        // Разделяем строку на слова по пробелам
        var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Переворачиваем массив слов
        var reversedWords = words.Reverse();

        // Объединяем слова обратно в строку
        var reversedSentence = string.Join(" ", reversedWords);

        // Отображаем перевёрнутую строку в Label
        ReversedLabel.Content = reversedSentence;
    }
}