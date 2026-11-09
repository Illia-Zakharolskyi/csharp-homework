using MagicCrystal.CrystalHeart.Helpers.Collections.List;

namespace MagicCrystal.CrystalHeart.Helpers.Collections.Dictionaries;

internal static class CrystaDicts
{
    internal static readonly Dictionary<string, List<string>> crystalMods = new()
    {
        { "neutral", PossibleAnswers.neutralAnswers },
        { "joking", PossibleAnswers.jokingAnswers },
        { "angry", PossibleAnswers.angryAnswers }
    };
}
