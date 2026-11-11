using OOPLearning3.Domain.Interfaces;

namespace OOPLearning3.Domain.Models;

internal class Player
{
    internal string Name { get; private set; }
    internal Weapon? EquippedWeapon { get; private set; }

    public Player(string name, Weapon? equippedWeapon)
    {
        Name = name;
        EquippedWeapon = equippedWeapon;
    }

    internal void DisplayInfoByCreating()
    {
        Console.WriteLine($"Created a new character with the name {Name}");
    }

    internal void WeaponAttack()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($" {Name} has no weapon to attack with");
            return;
        }

        Console.Write($"{Name} attacks ");
        EquippedWeapon.Attack();
    }

    internal void SpecialWeaponAttack()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($" {Name} has no weapon to perform a special attack with");
            return;
        }

        Console.Write($"{Name} performs a special attack ");
        EquippedWeapon.SpecialAttack();
    }

    internal void DisplayWeaponStats()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($" {Name} has no weapon equipped to display stats for");
            return;
        }

        Console.Write($"{Name} has ");
        EquippedWeapon.DisplayStats();
    }

    internal void SharpenWeapon()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($" {Name} has no weapon equipped to sharpen");
            return;
        }
        if (EquippedWeapon is not ISharpenable)
        {
            Console.WriteLine($" {Name} has an unsharpenable weapon equipped");
            return;
        }

        Console.Write($"{Name} successfully sharpened {EquippedWeapon.Name}! ");
        ISharpenable sharpenable = (ISharpenable)EquippedWeapon;
        sharpenable.Sharpen();
    }

    internal void ReloadWeapon()
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($" {Name} has no weapon equipped to reload");
            return;
        }
        if (EquippedWeapon is not IReloadable)
        {
            Console.WriteLine($" {Name} has an unreloadable weapon equipped");
            return;
        }

        Console.Write($"{Name} successfully reloaded {EquippedWeapon.Name}! ");
        IReloadable reloadable = (IReloadable)EquippedWeapon;
        reloadable.Reload();
    }
}