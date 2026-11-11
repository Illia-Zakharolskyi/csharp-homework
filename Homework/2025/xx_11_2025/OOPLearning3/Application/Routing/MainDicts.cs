using OOPLearning3.UI;

namespace OOPLearning3.Application.Routing;

internal static class MainDicts
{
    internal static readonly Dictionary<int, (string description, Action action)> availableActions = new()
    {
        { 0, ("Exit", () => Environment.Exit(0)) },
        { 1, ("View all demos", () => DemoRunner.RunAllDemos()) },
        { 2, ("View warrior and archer demos", () => DemoRunner.RunPlayersBowAndSwordDemo()) },
        { 3, ("View warrior demo", () => DemoRunner.RunPlayerSwordDemo()) },
        { 4, ("View archer demo", () => DemoRunner.RunPlayerBowDemo()) },
    };
}
