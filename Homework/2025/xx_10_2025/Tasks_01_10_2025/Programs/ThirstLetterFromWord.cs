using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class ThirstLetterFromWord : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to First Letter Extractor/!", '/', "", "", true);

        // приймаємо дані
        string userWord = StringHelper.ReadString("Enter a word: ", "invalid input, please try again");

        // виводимо результат
        Console.WriteLine(GetThirstLetter(userWord));
    }
    private static char GetThirstLetter(string word)
    {
        return word[0];
    }
}
