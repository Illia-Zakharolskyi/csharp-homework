namespace OOPLearning.Classes;

internal class Enemy
{
    // Ідентифікація
    internal string Name { get; init; } = "Enemy";

    // Здоров'я
    private float health;
    private float maxHealth = 100f;

    // Атака
    private float currentAttackPower;
    private float baseAttackPower = 20f;

    // Властивість для перевірки чи ворог живий
    internal bool IsAlive => health > 0;

    // Рівень ворога
    internal int level = 1;

    // init сеттер з валідацією для MaxHealth
    internal float MaxHealth
    {
        get => maxHealth;
        init
        {
            if (value is < 1 or > 200)
            {
                Console.WriteLine("Invalid value for MaxHealth, setting to 100.");
                maxHealth = 100f;
            }
            else
            {
                maxHealth = value;
            }
            // Встановлюємо початкове здоров'я рівним максимальному при ініціалізації
            health = maxHealth;
        }
    }

    // init сеттер з валідацією для BaseAttackPower
    internal float BaseAttackPower
    {
        get => baseAttackPower;
        init
        {
            if (value is < 1 or > 40)
            {
                Console.WriteLine("Invalid value for BaseAttackPower, setting to 20.");
                baseAttackPower = 20f;
            }
            else
            {
                baseAttackPower = value;
            }
            // Встановлюємо потужність атаки рівною базовій при ініціалізації
            currentAttackPower = baseAttackPower;
        }
    }

    // Методи класу
    internal void ShowInfoByCreation()
    {
        Console.WriteLine($"Created enemy: {Name}, Level: {level}, Health: {health:F2}/{maxHealth:F2}, Attack: {currentAttackPower:F2}");
    }
    internal void AttackTarget(Enemy target)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is dead and cannot attack");
            return;
        }

        target.ReceiveDamage(currentAttackPower, Name);
        Console.WriteLine($"{Name} attacks {target.Name}, dealing {currentAttackPower:F2} damage. {target.Name}'s health is now: {target.health:F2}");

        if (!target.IsAlive)
        {
            Console.WriteLine($"{Name} defeats {target.Name}!");
        }
    }

    internal void ReceiveDamage(float damage, string damagerName)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is already defeated and cannot take more damage");
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            health = 0;
        }
    }

    internal void Heal(float amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount of healing must be greater than 0");
            return;
        }
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is already defeated and cannot be healed");
            return;
        }

        // Обмеження лікування до максимального здоров'я
        float healedAmount = Math.Min(amount, maxHealth - health);
        health += healedAmount;

        Console.WriteLine($"{Name} is healed for {healedAmount:F2} hit points. Health is now: {health:F2}");
    }

    internal void LevelUp()
    {
        level++;

        // Збільшення максимального здоров'я та базової атаки при підвищенні рівня
        maxHealth *= 1.1f; // 10%
        baseAttackPower *= 1.05f; // 5%

        // Оновлення поточного здоров'я та атаки
        health = maxHealth;
        currentAttackPower = baseAttackPower;

        Console.WriteLine($"{Name} leveled up to {level}! New maximum health: {maxHealth:F2}, new base attack: {baseAttackPower:F2}");
    }
}