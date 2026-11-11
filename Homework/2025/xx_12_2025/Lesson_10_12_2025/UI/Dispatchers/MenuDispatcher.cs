// .Net 9.0

// Application
using Lesson_10_12_2025.Application.Utilities.Validators;

// UI
using Lesson_10_12_2025.UI.Models;

namespace Lesson_10_12_2025.UI.Dispatchers;

internal static class MenuDispatcher
{
    private static readonly Stack<Menu> menuStack = new();

    internal static void Run(Menu menu)
    {
        menuStack.Push(menu);

        while (menuStack.Count > 0)
        {
            var currentMenu = menuStack.Peek();
            var currentMenuActionMap = currentMenu.GetActionMap();
            Console.Clear();
            currentMenu.Display(currentMenuActionMap);


            int userChoice = InetegerValidator.ReadInteger(
                promptMessage: "enter your choice: ",
                invalidInputMessage: "Invalid input. Please try again.",
                allowedAnswers: new List<int>(currentMenuActionMap.Keys),
                invalidChoiceMessage: "Invalid choice."
            );

            currentMenuActionMap[userChoice].action.Invoke();
            _ = Console.ReadKey();
        }
    }

    internal static void PushMenu(Menu menu)
    {
        menuStack.Push(menu);
    }

    internal static void PopMenu()
    {
        if (menuStack.Count > 0)
        {
            _ = menuStack.Pop();
        }
    }
}
