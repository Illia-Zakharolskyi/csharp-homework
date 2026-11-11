namespace OOPLearning2.Domain.Classes;

internal class Weapon
{
    // Збиток
    private float damage = 20;

    // Діапазон
    private int range = 5;

    // геттери та init сеттери
    internal float Damage
    {
        get => damage;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine("Damage cannot be less than or equal to 0. Default value set.");
                damage = 20;
            }
            else
            {
                damage = value;
            }
        }
    }
    internal int Range
    {
        get => range;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine("Range cannot be less than or equal to 0. Default value set.");
                range = 5;
            }
        }
    }
}
