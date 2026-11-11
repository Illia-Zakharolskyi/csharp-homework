using OOPLearning2.UI;

namespace OOPLearning2.Application.Routing.Dictionaries;

internal static class DemoActionMap
{
    internal static readonly Dictionary<int, (string description, Action action)> availableActions = new()
    {
        { 0, ("Exit", () => Environment.Exit(0)) },
        { 1, ("Watch scenario", () => DemoRunner.RunScenarioDemo()) },
    };
}

