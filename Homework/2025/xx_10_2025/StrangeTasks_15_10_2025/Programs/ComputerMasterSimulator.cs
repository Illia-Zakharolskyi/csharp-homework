using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace StrangeTasks_15_10_2025.Programs;

internal class ComputerMasterSimulator : IRunnable
{
    public void Run()
    {
        double userEstFPS = FloatingHelper.ReadDouble("Enter the expected FPS: ", "This is not a valid number, try again!");

        double realFPS;
        GetComputerFPS(userEstFPS, out realFPS);

        Console.WriteLine($"Real FPS from expected: {realFPS}");

        UpgradeComputerFPS(ref realFPS);
        Console.WriteLine($"FPS under boost: {realFPS}");
    }
    private static void GetComputerFPS(double estimatedFPS, out double realFPS)
    {
        realFPS = estimatedFPS - estimatedFPS * 0.25;
    }
    private static void UpgradeComputerFPS(ref double FPS)
    {
        FPS += FPS * 0.10;
    }
}
