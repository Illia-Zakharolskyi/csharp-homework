using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class EasyConcatanation : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Easy Concatenator/!", '/', "", "", true);

        // приймаємо дані
        string userTextOne = StringHelper.ReadString("Enter the first text: ", "invalid input, please try again");
        string userTextTwo = StringHelper.ReadString("Enter the second text: ", "invalid input, please try again");

        // виводимо результат
        Console.WriteLine(Concatanate(userTextOne, userTextTwo));
    }
    private static string Concatanate(string oneText, string twoText)
    {
        return string.Join(" ", oneText, twoText);
    }
}
