using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;

namespace StrangeTasks_15_10_2025.Programs;

internal class ExitProgram : IRunnable
{
    public void Run()
    {
        Console.Clear();

        Console.WriteLine("Goodbye!:)");

        _ = Console.ReadKey();
        Environment.Exit(0);
    }
}
