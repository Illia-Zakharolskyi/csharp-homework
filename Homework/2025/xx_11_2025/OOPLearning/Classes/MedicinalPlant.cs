namespace OOPLearning.Classes;

internal class MedicinalPlant
{
    private readonly Dictionary<string, int> collectedPlants = new();

    internal void CollectPlant(string plantName, int quantity = 1)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("the amount must be greater than 0");
            return;
        }

        if (collectedPlants.ContainsKey(plantName))
        {
            collectedPlants[plantName] += quantity;
            Console.WriteLine($"the amount added: {quantity} units of plant {plantName}");
        }
        else
        {
            collectedPlants[plantName] = quantity;
            Console.WriteLine($"the new plant added: {plantName} in quantity {quantity}");
        }
    }

    internal void ShowCollectedPlants()
    {
        if (collectedPlants.Count == 0)
        {
            Console.WriteLine("the medicinal plants have not been collected");
            return;
        }

        Console.WriteLine("the collected medicinal plants:");

        foreach (var plant in collectedPlants)
        {
            Console.WriteLine($"- {plant.Key}: {plant.Value} units");
        }
    }

    internal string? CreateMedicine(string medicineName)
    {
        Dictionary<string, Dictionary<string, int>> recipes = new()
        {
            { "the healing potion", new Dictionary<string, int> { {"Chamomile", 3 }, { "Mint", 5 } } },
            { "the curing potion", new Dictionary<string, int> { { "Aloe", 4 }, { "Calendula", 2 } } },
            { "the strength potion", new Dictionary<string, int> { { "Ginseng", 2 }, { "Echinacea", 3 } } }
        };

        if (!recipes.ContainsKey(medicineName))
        {
            Console.WriteLine($"Recipe for '{medicineName}' not found.");
            return null;
        }

        Dictionary<string, int> requiredPlants = recipes[medicineName];

        foreach (var plant in requiredPlants)
        {
            if (!collectedPlants.ContainsKey(plant.Key))
            {
                Console.WriteLine($"the plant is not collected: {plant.Key}");
                return null;
            }

            if (collectedPlants[plant.Key] < plant.Value)
            {
                Console.WriteLine($"Not enough of plant: {plant.Key}. Need {plant.Value} units, but only {collectedPlants[plant.Key]} are available.");
                return null;
            }

            collectedPlants[plant.Key] -= plant.Value;

            if (collectedPlants[plant.Key] == 0)
            {
                Console.WriteLine($"the plant {plant.Key} has been removed due to zero quantity");
                _ = collectedPlants.Remove(plant.Key);
            }
        }

        Console.WriteLine($"the medicine '{medicineName}' has been created");
        return medicineName;
    }
}
