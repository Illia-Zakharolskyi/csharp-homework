namespace OOPLearning.Classes;

internal class Recipe
{
    internal string Name { get; init; } = String.Empty;
    private readonly Dictionary<string, string> ingredients = new();

    internal void AddIngredient(string ingredient, string quantity = "1 шт.")
    {
        if (string.IsNullOrEmpty(ingredient) || string.IsNullOrEmpty(quantity))
        {
            Console.WriteLine("Invalid ingredient name or quantity");
            return;
        }
        if (ingredients.ContainsKey(ingredient))
        {
            ingredients[ingredient] += quantity;
        }
        else
        {
            ingredients[ingredient] = quantity;
        }

        Console.WriteLine($"New ingredient - {ingredient}, in quantity {ingredients[ingredient]}");
    }
    internal void ChangeIngredientQuantity(string ingredient, string quantity)
    {
        if (!ingredients.ContainsKey(ingredient))
        {
            Console.WriteLine("The ingredient does not exist");
            return;
        }

        ingredients[ingredient] = quantity;

        Console.WriteLine($"Quantity of {ingredient} has been changed to {quantity}");
    }
    internal void RemoveIngredient(string ingredient)
    {
        if (!ingredients.ContainsKey(ingredient))
        {
            Console.WriteLine("The ingredient does not exist");
            return;
        }

        _ = ingredients.Remove(ingredient);

        Console.WriteLine($"The ingredient {ingredient} has been removed from the recipe");
    }
    internal void ShowRecipeIngredients()
    {
        if (ingredients.Count == 0)
        {
            Console.WriteLine("Ingredients are missing");
            return;
        }

        Console.WriteLine($"Ingredients for recipe '{Name}':");

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"- {ingredient.Key}: {ingredient.Value}");
        }
    }

    internal Dictionary<string, string> GetIngredients()
    {
        return new Dictionary<string, string>(ingredients);
    }
}
