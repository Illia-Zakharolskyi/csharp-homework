using OOPLearning3.Domain.Defaults;
using OOPLearning3.Domain.Interfaces;
using OOPLearning3.Domain.Models;

namespace OOPLearning3.Domain.Weapons;

internal class Sword : Weapon, ISharpenable
{
    // Довжини
    private float bladeLength;

    // рівні
    public int SharpenLevel { get; private set; } = 0;

    // Властивість для bladeLength
    internal float BladeLength
    {
        get => bladeLength;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine($"Invalid value '{value}' for blade length, default value set");
                bladeLength = WeaponDefaults.DefaultBladeLength;
            }
            else
            {
                bladeLength = value;
            }
        }
    }
    // методи классу
    public void Sharpen()
    {
        if (SharpenLevel == WeaponDefaults.MaxSharpenLevel)
        {
            Console.WriteLine($"Maximum sharpening level reached({SharpenLevel} sharpening level)");
            return;
        }

        SharpenLevel++;
        basicDamage *= WeaponDefaults.SharpenLevelDamageMultipliers[SharpenLevel - 1];
        currentDamage = basicDamage;

        Console.WriteLine($"Current sharpening level: {(SharpenLevel == WeaponDefaults.MaxSharpenLevel ? $"{SharpenLevel} (maximum)" : $"{SharpenLevel}")}");
    }

    // override методи
    internal override void Attack()
    {
        Console.WriteLine($"Sword with name {Name} deals {currentDamage:F2} units of damage");
        ApplyFatigue();
    }

    internal override void DisplayStats()
    {
        Console.WriteLine($"Sword with name {Name}: basic damage {basicDamage:F2}, current damage {currentDamage:F2}, blade length {bladeLength:F2} meters, shots fired {attackCount}");
    }

    internal override void SpecialAttack()
    {
        float specialDamage = currentDamage * WeaponDefaults.SwordSpecialAttackMultiplier;

        Console.WriteLine($"Sword with name {Name} deals {specialDamage:F2} units of damage");
        ApplyFatigue();
    }
}