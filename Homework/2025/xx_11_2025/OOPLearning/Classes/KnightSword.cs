namespace OOPLearning.Classes;

internal class KnightSword
{
    // Ідентификація
    internal string SwordOwner { get; init; } = string.Empty;

    // Збиток
    private float currentAttackPower;
    internal float baseAttackPower = 35;

    // Прочність
    private float currentDurability;
    private float baseDurability = 110f;

    // Властивість для перевірки чи меч зламаний
    internal bool IsBroken => currentDurability <= 0;

    // Рівень меча
    internal int swordLevel = 1;

    // init сеттери для baseAttackPower
    internal float BaseAttackPower
    {
        get => currentAttackPower;
        init
        {
            if (value is < 1 or > 150)
            {
                Console.WriteLine("The value is not within the allowed range for the knight's sword base attack power, default value set");
                baseAttackPower = 35;
            }
            else
            {
                baseAttackPower = value;
            }

            // Встановлюємо потужність атаки рівною базовій при ініціалізації
            currentAttackPower = baseAttackPower;
        }
    }

    // init сеттери для baseDurability
    internal float BaseDurability
    {
        get => currentDurability;
        init
        {
            if (value is < 50 or > 200)
            {
                Console.WriteLine("The value is not within the allowed range for the knight's sword base durability, default value set");
                baseDurability = 110;
            }
            else
            {
                baseDurability = value;
            }
            // Встановлюємо поточну міцність рівною базовій при ініціалізації
            currentDurability = baseDurability;
        }
    }

    // методи класу
    internal void ShowSwordInfo()
    {
        Console.WriteLine($"Sword owner: {SwordOwner}, damage: {baseAttackPower:F2}, durability: {baseDurability}");
    }

    internal void ShowSwordDurability()
    {
        var durabilityLevels = new Dictionary<float, string>
        {
            { baseDurability * 0.70f, "Sword durability is high" }, // 70% of base durability
            { baseDurability * 0.50f, "Sword durability is medium" }, // 50% of base durability
            { baseDurability * 0.30f, "Sword durability is low" }, // 30% of base durability
            { baseDurability * 0.01f,  "Sword durability is very low" }, // 1% of base durability
            { 0.00f,  "Sword is broken" } // 0.00 durability
        };

        foreach (var level in durabilityLevels)
        {
            if (currentDurability >= level.Key)
            {
                Console.WriteLine(level.Value);
                return;
            }
        }
    }

    internal void Attack(Enemy target)
    {
        if (IsBroken)
        {
            Console.WriteLine("Sword is broken and cannot attack");
            return;
        }

        target.ReceiveDamage(currentAttackPower, SwordOwner);
        currentDurability -= 3;
        if (currentDurability < 0)
        {
            currentDurability = 0;
        }

        Console.WriteLine($"{SwordOwner} deals {currentAttackPower:F2} damage to {target.Name}, now having {currentDurability} durability left");
    }

    internal void UpgradeSword()
    {
        if (IsBroken)
        {
            Console.WriteLine("Sword is broken and cannot be upgraded");
            return;
        }

        swordLevel++;

        // Збільшуємо базовий збиток та міцність меча при кожному рівні
        baseAttackPower += baseAttackPower * 0.20f;
        baseDurability += baseDurability * 0.10f;

        // Оновлюємо поточні значення збитку та міцності
        currentAttackPower = baseAttackPower;
        currentDurability = baseDurability;

        Console.WriteLine($"Sword {SwordOwner} upgraded to level {swordLevel}. New damage: {baseAttackPower:F2} units, new durability: {baseDurability:F2} units");
    }
}