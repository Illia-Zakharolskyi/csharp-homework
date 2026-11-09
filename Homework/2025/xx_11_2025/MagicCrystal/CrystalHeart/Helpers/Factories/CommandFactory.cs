using MagicCrystal.CrystalHeart.Core;
using MagicCrystal.CrytsalInfo.Commands;
using MagicCrystal.UserProfile;

namespace MagicCrystal.CrystalHeart.Helpers.Factories;

internal static class CommandFactory
{
    internal static Dictionary<string, ICommand> Create(User user)
    {
        return new Dictionary<string, ICommand>()
        {
            { "exit", new ExitCommand() },
            { "change style", new ChangeCrystalModCommand { user = user } },
        };
    }
}
