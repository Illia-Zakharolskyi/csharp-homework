using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class IsNumberEven : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Even Number Checker/!", '/', "", "", true);

        // приймаємо дані
        int userNumber = IntegersHelper.ReadInt("Enter an integer: ", "invalid input, please enter an integer");

        // виводимо результат
        Console.WriteLine($"The number {userNumber} is {CheckIsEven(userNumber)}.");
    }
    private static string CheckIsEven(int number)
    {
        return number % 2 == 0 ? "even" : "odd";
    }
}
