using MagicCrystal.CrystalHeart.Core;
using MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;
using MagicCrystal.CrystalHeart.Utilities.Validators;
using MagicCrystal.UserProfile;

namespace MagicCrystal.CrytsalInfo.Commands;

internal class ChangeCrystalModCommand : ICommand
{
    internal required User user { get; init; }

    public void Execute()
    {
        string newMod = StringValidator.ReadInput("enter new joke style (neutral, joking, angry): ", "Invalid input", CrystaDicts.crystalMods.Keys.ToList(), "such a style is not available");
        user.SelectedCrystalMode = newMod.ToLower();
    }
}
