namespace OOPLearning.Classes;

internal class TreasureChest
{
    private readonly Dictionary<string, int> treasures = new();
    private bool isOpen = false;

    internal void AddTreasure(string treasure, int quantity = 1)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("the amount must be greater than 0");
            return;
        }
        if (treasures.ContainsKey(treasure))
        {
            treasures[treasure] += quantity;
            Console.WriteLine($"the amount of {quantity} units of treasure {treasure} has been added ");
        }
        else
        {
            treasures[treasure] = quantity;
            Console.WriteLine($"the amount of {quantity} units of treasure {treasure} has been added ");
        }
    }

    internal void OpenChest()
    {
        string text = isOpen ? "treasure chest is already open, nothing new to add" : "treasure chest is now open, here's what's inside:";
        Console.WriteLine(text);
        if (isOpen)
        {
            return;
        }

        isOpen = true;

        if (treasures.Count == 0)
        {
            Console.WriteLine("nothing here");
            return;
        }

        foreach (var treasure in treasures)
        {
            Console.WriteLine($"- {treasure.Key}, amount {treasure.Value} шт");
        }
    }
    internal void CloseChest()
    {
        if (!isOpen)
        {
            Console.WriteLine("treasure chest is already closed");
            return;
        }

        isOpen = false;
        Console.WriteLine("treasure chest is now closed");
    }
}