using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.CollectionHelpers;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace StrangeTasks_15_10_2025.Programs;

internal class MagicalKitchen : IRunnable
{
    public void Run()
    {
        Random rnd = new();
        string dish;


        string userAnswer = StringHelper.ReadString("The dish will be generated automatically (yes/no)? ", "Invalid answer", new List<string> { "yes", "no", "y", "n", "1", "0" }, true, "This answer is not available");

        if (userAnswer is "no" or "n" or "0")
        {
            ListHelper.DisplayList("Available fruits:", MagicalKitchenDicts.dishesIngridients.Keys.ToList());

            dish = StringHelper.ReadString("Enter a fruit: ", "Fruit cannot be empty!", MagicalKitchenDicts.dishesIngridients.Keys.ToList(), true, "This fruit is not available!");
        }
        else
        {
            CreateNewDish(rnd, out dish);
        }

        int userIngridients = IntegersHelper.ReadInteger("How many ingredients have you already prepared? ", "This is not a valid number, try again!");

        UpdateNecessaryIngridients(dish, ref userIngridients);

        if (userIngridients == 0)
        {
            Console.WriteLine("You have already prepared the dish!");
        }
        else
        {
            Console.WriteLine($"You still need to prepare {userIngridients} ingredients.");
        }
    }
    private static void CreateNewDish(Random rnd, out string newNameOfDish)
    {
        List<string> keys = MagicalKitchenDicts.dishesIngridients.Keys.ToList();

        newNameOfDish = keys[rnd.Next(keys.Count)];
    }
    private static void UpdateNecessaryIngridients(string dish, ref int usedIngridients)
    {
        usedIngridients = MagicalKitchenDicts.dishesIngridients[dish.ToLower()] - usedIngridients <= 0 ? 0 : MagicalKitchenDicts.dishesIngridients[dish.ToLower()] - usedIngridients;
    }
}
