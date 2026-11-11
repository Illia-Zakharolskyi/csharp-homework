// .NET 9.0


// Utilities
using CardGame.src.Application.Utilities.Validators;
using CardGame.src.UI.Interfaces;




// UI

namespace CardGame.src.UI.Dispatchers;

internal class MenuDispatcher
{
    private readonly Stack<IMenu> menuStack = new();

    internal void Run(IMenu menu)
    {
        menuStack.Push(menu);

        while (menuStack.Count > 0)
        {
            var currentMenu = menuStack.Peek();
            var currentMenuActionMap = currentMenu.GetActionMap();
            Console.Clear();
            currentMenu.Display();


            int userChoice = InetegerValidator.ReadInteger(
                promptMessage: "Enter your choice: ",
                invalidInputMessage: "Invalid input. Please try again.",
                allowedAnswers: new List<int>(currentMenuActionMap.Keys),
                invalidChoiceMessage: "That option is not available"
            );

            currentMenuActionMap[userChoice].action.Invoke();
            _ = Console.ReadKey();
        }
    }

    internal void PushMenu(IMenu menu)
    {
        menuStack.Push(menu);
    }

    internal void PopMenu()
    {
        if (menuStack.Count > 0)
        {
            _ = menuStack.Pop();
        }
    }
}