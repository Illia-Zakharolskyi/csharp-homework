using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class DoublingNumber : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Number Doubling/!", '/', "", "", true);

        // приймаемо дані
        decimal userNumber = FloatingPointNumbersHelper.ReadDecimal("Enter the number you want to double: ", "invalid input, please enter a number");

        // подвоюємо
        decimal result = Doubling(userNumber);

        // виводимо результат
        Console.WriteLine($"The result of doubling the number {userNumber:F2} is {result:F2}");
    }
    private static decimal Doubling(decimal number)
    {
        return number * 2;
    }
}
