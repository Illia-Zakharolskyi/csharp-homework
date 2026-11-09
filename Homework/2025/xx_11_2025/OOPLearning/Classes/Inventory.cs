namespace OOPLearning.Classes;

internal class Inventory
{
    private readonly Dictionary<string, int> items = new();

    internal void AddItem(string item, int amount = 1)
    {
        if (amount <= 0)
        {
            Console.WriteLine("The amount must be greater than 0");
            return;
        }

        if (items.ContainsKey(item))
        {
            items[item] += amount;
            Console.WriteLine($"The amount of '{item}' has been increased by {amount}");
        }
        else
        {
            items[item] = amount;
            Console.WriteLine($"Added new item: '{item}', quantity {amount}.");
        }
    }

    internal void RemoveItem(string item)
    {
        if (!items.ContainsKey(item))
        {
            Console.WriteLine($"Item '{item}' not found in inventory for removal.");
            return;
        }

        _ = items.Remove(item);
        Console.WriteLine($"Item '{item}' removed from inventory.");
    }

    internal void ShowInventory()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty, nothing to show");
            return;
        }

        Console.WriteLine("Inventory contains:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Value} units of item {item.Key}");
        }
    }

    internal void ClearInvenory()
    {
        items.Clear();
        Console.WriteLine("Inventory cleared");
    }
}
