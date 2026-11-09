using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class GreetingsByName : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Welcome to Greetings by Name/!", '/', "", "", true);

        // приймаемо дані
        string userName = StringHelper.ReadString("Enter your name: ", "invalid input, please try again");

        // вітаємо
        SayHello(userName);
    }
    private static void SayHello(string name)
    {
        Console.WriteLine($"Hello {name}!");
    }
}
