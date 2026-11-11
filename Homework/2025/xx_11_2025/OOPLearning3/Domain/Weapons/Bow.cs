using OOPLearning3.Domain.Defaults;
using OOPLearning3.Domain.Interfaces;
using OOPLearning3.Domain.Models;

namespace OOPLearning3.Domain.Weapons;

internal class Bow : Weapon, IReloadable
{
    // кількість стріл
    private int currentArrowCount;
    private int maxArrowCount;

    // Властивість для maxArrowCount
    internal int MaxArrowCount
    {
        get => maxArrowCount;
        init
        {
            if (value <= 0)
            {
                Console.WriteLine($"Invalid value '{value}' for arrow count in bow, default value set");
                maxArrowCount = WeaponDefaults.BowDefaultArrowCount;
            }
            else
            {
                maxArrowCount = value;
            }

            currentArrowCount = maxArrowCount;
        }
    }

    // властивість для currentArrowCount
    internal int CurrentArrowCount
    {
        get => currentArrowCount;
    }

    // Методи классу
    public void Reload()
    {
        if (currentArrowCount == maxArrowCount)
        {
            Console.WriteLine($"Arrow count is maximum({MaxArrowCount} arrows), no need to reload");
            return;
        }

        currentArrowCount = maxArrowCount;
        Console.WriteLine($"Arrow count has been replenished to maximum({MaxArrowCount} arrows)!");
    }

    // override методи
    internal override void Attack()
    {
        if (currentArrowCount <= 0)
        {
            Console.WriteLine("Not enough arrows for a bow shot");
            return;
        }

        currentArrowCount--;

        Console.WriteLine($"Bow with name {Name} deals {currentDamage:F2} units of damage");
        ApplyFatigue();
    }
    internal override void SpecialAttack()
    {
        if (currentArrowCount <= 0)
        {
            Console.WriteLine("Not enough arrows for a special bow shot");
            return;
        }

        float specialDamage = currentDamage * currentArrowCount;

        Console.WriteLine($"Bow with name {Name} fires all arrows and deals {specialDamage:F2} units of damage");
        ApplyFatigue(currentArrowCount);
        currentArrowCount = 0;
    }

    internal override void DisplayStats()
    {
        Console.WriteLine($"Bow with name {Name}: basic damage {basicDamage:F2}, current damage {currentDamage:F2}, arrow count {currentArrowCount}, shots fired {attackCount}");
    }
}
