using OOPLearning.Application.Formatters;
using OOPLearning.Classes;

namespace OOPLearning.Application.Runners;

internal static class DemoRunner
{
    internal static void RunAllDemos()
    {
        List<Action> allDemos = new()
        {
            RunBankAccountDemo,
            RunEnemyDemo,
            RunMagicDemo,
            RunTreausreChestDemo,
            RunInventoryDemo,
            RunMedicinalPlantDemo,
            RunTrapDemo,
            RunKnightSwordDemo,
            RunRecipeDemo,
        };

        Console.WriteLine(new string('~', 15) + " Start of all demonstrations " + new string('~', 15));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(allDemos, "Demonstration", '*', 70);
        Console.WriteLine();
        Console.WriteLine(new string('~', 15) + " End of all demonstrations " + new string('~', 15));
    }
    internal static void RunBankAccountDemo()
    {
        BankAccount account = new()
        {
            OwnerName = "Іван Петренко"
        };

        var actions = new List<Action>
        {
            () => account.ShowAccountInfo(),
            () => account.DepositMoney(1500m),
            () => account.ShowAccountInfo(),
            () => account.WithdrawMoney(500m),
            () => account.ShowAccountInfo(),
            () => account.WithdrawMoney(2000m),
            () => account.ShowAccountInfo()
        };

        Console.WriteLine(new string('=', 10) + " Start of bank account actions presentation " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Bank account action", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of bank account actions presentation " + new string('=', 10));
    }
    internal static void RunEnemyDemo()
    {
        Enemy goblin = new()
        {
            Name = "Goblin",
            MaxHealth = 30f,
            BaseAttackPower = 6f
        };
        Enemy skeleton = new()
        {
            Name = "Skeleton",
            MaxHealth = 25f,
            BaseAttackPower = 8f
        };

        List<Action> actions = new()
        {
            () => goblin.AttackTarget(skeleton),
            () => skeleton.AttackTarget(goblin),
            () => goblin.AttackTarget(skeleton),
            () => goblin.LevelUp(),
            () => skeleton.Heal(10),
            () => skeleton.AttackTarget(goblin),
            () => goblin.AttackTarget(skeleton),
            () => skeleton.AttackTarget(goblin),
            () => skeleton.LevelUp(),
            () => goblin.AttackTarget(skeleton),
            () => skeleton.AttackTarget(goblin),
            () => goblin.Heal(2),
            () => skeleton.AttackTarget(goblin),
            () => goblin.AttackTarget(skeleton),
            () => skeleton.AttackTarget(goblin)
        };

        goblin.ShowInfoByCreation();
        skeleton.ShowInfoByCreation();

        Console.WriteLine(new string('=', 5) + " Start of battle! " + new string('=', 5));
        Console.WriteLine();

        RunDemoClassesFormatter.RunActions(actions, "Turn", '-', 90);

        Console.WriteLine();
        Console.WriteLine(new string('=', 5) + " End of battle! " + new string('=', 5));

        Console.WriteLine($"Winner: {(goblin.IsAlive ? goblin.Name : skeleton.Name)}");
    }
    internal static void RunMagicDemo()
    {
        Magic magic = new();
        magic.CastSpell("fire bullet");
        magic.UsePotion("health potion");
    }
    internal static void RunTreausreChestDemo()
    {
        TreasureChest chest = new();

        var actions = new List<Action>
        {
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.AddTreasure("Gold", 6),
            () => chest.AddTreasure("Diamonds", 3),
            () => chest.OpenChest(),
            () => chest.AddTreasure("Gold", 4),
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.CloseChest(),
        };

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the treasure chest " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the treasure chest", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the treasure chest " + new string('=', 10));
    }
    internal static void RunInventoryDemo()
    {
        Inventory inventory = new();

        List<Action> actions = new()
        {
            () => inventory.ShowInventory(),
            () => inventory.AddItem("Sword"),
            () => inventory.AddItem("Shield", 2),
            () => inventory.ShowInventory(),
            () => inventory.AddItem("Sword", 3),
            () => inventory.ShowInventory(),
            () => inventory.RemoveItem("Bow"),
            () => inventory.RemoveItem("Shield"),
            () => inventory.ShowInventory(),
            () => inventory.ClearInvenory(),
            () => inventory.ShowInventory()
        };

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the inventory " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the inventory", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the inventory " + new string('=', 10));
    }
    internal static void RunMedicinalPlantDemo()
    {
        MedicinalPlant plantCollector = new();

        List<Action> actions = new()
        {
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CollectPlant("Romashka", 3),
            () => plantCollector.CollectPlant("M'ята", 5),
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CollectPlant("Aloe", 4),
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CreateMedicine("potion of mana restoration"),
            () => plantCollector.CreateMedicine("potion of healing"),
            () => plantCollector.CreateMedicine("potion of strength"),
            () => plantCollector.CreateMedicine("potion of the unknown")
        };

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the medicinal plant collection " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the medicinal plant collection", '-', 70);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the medicinal plant collection " + new string('=', 10));
    }
    internal static void RunTrapDemo()
    {
        Trap trap = new();
        var actions = new List<Action>
        {
            () => trap.TriggerTrap(),
            () => trap.ResetTrap(),
            () => trap.TriggerTrap(),
            () => trap.TriggerTrap(),
            () => trap.ResetTrap(),
            () => trap.ResetTrap()
        };

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the trap " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the trap", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the trap " + new string('=', 10));
    }
    internal static void RunKnightSwordDemo()
    {
        KnightSword knightSword = new()
        {
            SwordOwner = "hero",
            BaseAttackPower = 35,
            BaseDurability = 50
        };
        Enemy enemy1 = new()
        {
            Name = "ogr",
            MaxHealth = 50f,
            BaseAttackPower = 10f
        };
        Enemy enemy2 = new()
        {
            Name = " troll ",
            MaxHealth = 60f,
            BaseAttackPower = 12f
        };

        var actions = new List<Action>
        {
            () => knightSword.Attack(enemy1),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.UpgradeSword(),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy1),
            () => knightSword.UpgradeSword(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability()
        };

        knightSword.ShowSwordInfo();

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the knight's sword " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the knight's sword", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the knight's sword " + new string('=', 10));
    }
    internal static void RunRecipeDemo()
    {
        Recipe recipe = new()
        {
            Name = "Pancakes on kefir"
        };

        var actions = new List<Action>
        {
            () => recipe.ShowRecipeIngredients(),
            () => recipe.AddIngredient("Kefir", "251 ml."),
            () => recipe.ChangeIngredientQuantity("Kefir", "250 ml."),
            () => recipe.ChangeIngredientQuantity("Kefir", "250 ml."),
            () => recipe.ShowRecipeIngredients(),
            () => recipe.AddIngredient("Flour", "350 g."),
            () => recipe.AddIngredient("Eggs", "2 pcs."),
            () => recipe.AddIngredient("Sugar", "1.5 tbsp"),
            () => recipe.AddIngredient("Salt", "1/3 tbsp"),
            () => recipe.AddIngredient("Baking Soda", "1/2 tbsp"),
            () => recipe.ShowRecipeIngredients(),
            () => recipe.RemoveIngredient("Kefir"),
            () => recipe.RemoveIngredient("Kefir"),
            () => recipe.ShowRecipeIngredients()
        };

        Console.WriteLine(new string('=', 10) + " Start of presentation of actions with the recipe " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Action with the recipe", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " End of presentation of actions with the recipe " + new string('=', 10));
    }
    internal static void RunExitDemo()
    {
        Environment.Exit(0);
    }
}