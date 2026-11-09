namespace MagicCrystal.CrystalHeart.Helpers.Collections.List;

internal static class PossibleAnswers
{
    internal static readonly List<string> neutralAnswers = new()
    {
        "yes", "no", "maybe", "probably yes", "probably no"
    };
    internal static readonly List<string> jokingAnswers = new()
    {
        "Well, it depends", "Well, what else?", "Yes, but only if you're wearing dinosaur socks", "No, because I said so",
        ""
    };
    internal static readonly List<string> angryAnswers = new()
    {
        "yes", "no", "maybe", "probably yes", "probably no"
    };
}
