// .NET9.0
namespace Lesson_03_12_2025.UI;

internal static class MainMenu
{
    internal static void Display(Dictionary<int, (string description, Action avtion)> actions)
    {
        Console.WriteLine($"{"Id",-6} | {"Description"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in actions)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
