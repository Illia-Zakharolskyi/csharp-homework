using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.CollectionHelpers;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace StrangeTasks_15_10_2025.Programs;

internal class Juicer : IRunnable
{
    public void Run()
    {
        ListHelper.DisplayList("Available fruits: ", JuicerDicts.fruitJuices.Keys.ToList());
        Console.WriteLine();

        string userFruit = StringHelper.ReadString("Enter a fruit: ", "Fruit cannot be empty!", JuicerDicts.fruitJuices.Keys.ToList(), true, "This fruit is not available!");

        double amountOfJuice = GetAmountOfJuice(userFruit);
        Console.WriteLine($"Amount of juice from the fruit without 'magic' addition: {amountOfJuice}");

        AddJuiceInFruit(ref amountOfJuice);
        Console.WriteLine($"Amount of juice from the fruit with 'magic' addition: {amountOfJuice:F2}");
    }
    private static double GetAmountOfJuice(string fruit)
    {
        return JuicerDicts.fruitJuices[fruit.ToLower()];
    }
    private static void AddJuiceInFruit(ref double amountOfJuice)
    {
        amountOfJuice *= 1.25;
    }
}
