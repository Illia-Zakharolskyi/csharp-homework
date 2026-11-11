using OOPLearning2.Application.Routing.Dictionaries;

namespace OOPLearning2.UI;

internal static class MainMenu
{
    internal static void Display()
    {
        Console.WriteLine($"{"Id",-6} | {"Description"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in DemoActionMap.availableActions)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
