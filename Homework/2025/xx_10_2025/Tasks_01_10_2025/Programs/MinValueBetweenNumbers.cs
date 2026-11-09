using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class MinValueBetweenNumbers : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Minimum Value Finder/!", '/', "", "", true);

        // приймаємо дані
        decimal userNumberA = FloatingPointNumbersHelper.ReadDecimal("Enter the first number: ", "invalid input, please enter a number");
        decimal userNumberB = FloatingPointNumbersHelper.ReadDecimal("Enter the second number: ", "invalid input, please enter a number");

        // шукаємо мінімальне
        decimal minValue = MinValue(userNumberA, userNumberB);

        // виводимо результат
        Console.WriteLine($"The minimum number between {userNumberA:F2} and {userNumberB:F2} is {minValue:F2}");
    }
    private static decimal MinValue(decimal a, decimal b)
    {
        return a < b ? a : b;
    }
}
