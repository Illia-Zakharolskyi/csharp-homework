// .NET.9.0
namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task2
{
    internal static void Execute()
    {
        Console.Write("Enter the angle in degrees: ");

        if (!int.TryParse(Console.ReadLine(), out int deg))
        {
            Console.WriteLine("Error: invalid input.");
            return;
        }

        double? result = DegToRad(deg);

        if (result == null)
        {
            Console.WriteLine("Error: the angle must be between 0 and 360 degrees.");
            return;
        }

        Console.WriteLine("Angle in radians: " + result);
    }

    private static double? DegToRad(int deg)
    {
        if (deg is < 0 or > 360)
        {
            return null;
        }

        double rad = deg * Math.PI / 180.0;
        return rad;
    }
}