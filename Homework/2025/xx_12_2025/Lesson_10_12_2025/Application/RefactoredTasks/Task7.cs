// .NET.9.0
using System.Text;

namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task7
{
    internal static void Execute()
    {
        int[]? degrees = ReadUserDegrees();

        if (degrees == null || degrees.Length == 0)
        {
            Console.WriteLine("Invalid input: no angles provided for conversion.");
            return;
        }

        double[] radians = ConvertDegreesToRads(degrees);

        PrintResult(radians);
    }
    private static int[]? ReadUserDegrees()
    {
        List<int> degrees = new();

        while (true)
        {
            Console.Write("Enter the angle in degrees (or 'exit' to finish): ");

            string? input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "exit")
            {
                return degrees.ToArray();
            }

            if (int.TryParse(input, out int deg))
            {
                degrees.Add(deg);
            }

            else
            {
                Console.WriteLine("Error: invalid input.");
            }
        }
    }
    private static double[] ConvertDegreesToRads(int[] degrees)
    {
        double[] result = new double[degrees.Length];

        for (int i = 0; i < degrees.Length; i++)
        {
            int d = degrees[i];

            if (d is < 0 or > 360)
            {
                result[i] = double.NaN;
                continue;
            }

            result[i] = d * Math.PI / 180;
        }

        return result;
    }
    internal static void PrintResult(double[] radians)
    {
        StringBuilder sb = new();
        _ = sb.Append("Received radians: ");

        for (int i = 0; i < radians.Length; i++)
        {
            if (!double.IsNaN(radians[i]))
            {
                _ = sb.Append(radians[i]);
            }
            else
            {
                _ = sb.Append("Invalid value");
            }

            if (i < radians.Length - 1)
            {
                _ = sb.Append(", ");
            }
        }

        Console.WriteLine(sb.ToString());
    }
}