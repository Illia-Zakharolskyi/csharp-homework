// .Net 9.0

// Application
using Lesson_10_12_2025.Application.RefactoredTasks;
using Lesson_10_12_2025.UI.Dispatchers;
using Lesson_10_12_2025.UI.Interfaces;
// UI
using Lesson_10_12_2025.UI.Models;

namespace Lesson_10_12_2025.UI.Menus;

internal class Task7Menu : Menu, IMenu
{
    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("return", () => MenuDispatcher.PopMenu()) },
            { 1, ("execute task", () => Task7.Execute()) }
        };
    }
}
