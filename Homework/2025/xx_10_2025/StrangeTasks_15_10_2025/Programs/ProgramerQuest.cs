using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.ProgramsDicts;

namespace StrangeTasks_15_10_2025.Programs;

internal class ProgramerQuest : IRunnable
{
    public void Run()
    {
        Random rnd = new();
        double mania = 250.00;

        Console.WriteLine($"Mana before the spell: {mania}");

        string spell;
        GenerateNewSpell(rnd, out spell);
        UpdateManiaAfterSpellsDamage(ref mania, spell);

        Console.WriteLine($"Mana after the spell: {mania:F2}");
    }
    private static void GenerateNewSpell(Random rnd, out string newSpell)
    {
        List<string> spells = new(ProgramerQuestDicts.spellDamages.Keys);

        newSpell = spells[rnd.Next(spells.Count)];
    }
    private static void UpdateManiaAfterSpellsDamage(ref double mania, string spell)
    {
        mania -= ProgramerQuestDicts.spellDamages[spell];
    }
}
