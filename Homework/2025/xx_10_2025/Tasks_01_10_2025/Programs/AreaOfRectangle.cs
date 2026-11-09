using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class AreaOfRectangle : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle($"Welcome to rectangle calculator/!", '/', "", "", true);

        // приймаємо дані
        decimal userWidth = FloatingPointNumbersHelper.ReadDecimal("Enter the width of the rectangle: ", "invalid input, please enter a number");
        decimal userHigh = FloatingPointNumbersHelper.ReadDecimal("Enter the height of the rectangle: ", "invalid input, please enter a number");

        // рахуємо площу
        decimal cubeArea = CalculateArea(userWidth, userHigh);

        // виводимо результат
        Console.WriteLine($"The area of the rectangle with width {userWidth:F2} and height {userHigh:F2} is {cubeArea:F2}");
    }
    private static decimal CalculateArea(decimal width, decimal high)
    {
        return width * high;
    }
}
