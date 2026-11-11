// .NET.9.0
namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task3
{
    internal static void Execute()
    {
        Console.Write("Enter the first angle in degrees: ");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Error: invalid input.");
            return;
        }

        Console.Write("Enter the second angle in degrees: ");
        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Error: invalid input.");
            return;
        }

        double? resultA = DegToRad(a);
        double? resultB = DegToRad(b);

        if (resultA == null || resultB == null)
        {
            Console.WriteLine("Error: the angles must be between 0 and 360 degrees.");
            return;
        }

        Console.WriteLine($"First angle in radians: {resultA}");
        Console.WriteLine($"Second angle in radians: {resultB}");
    }

    private static double? DegToRad(int deg)
    {
        if (deg is < 0 or > 360)
        {
            return null;
        }

        return deg * Math.PI / 180.0;
    }
}