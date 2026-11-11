// .NET 9.0

// Application
using Lesson_03_12_2025.Application.Helpers.Dictionaries;
using Lesson_03_12_2025.Application.Utilities.Validators;

namespace Lesson_03_12_2025.UI;

internal class MainHandler
{
    private readonly MainDicts _mainDicts;

    internal MainHandler(MainDicts mainDicts)
    {
        _mainDicts = mainDicts;
    }

    internal void HandleUserInput()
    {
        int userChoice = IntegerValidator.ReadInteger(
            "Enter action number: ",
            "Invalid input. Please try again.",
            new List<int>(_mainDicts.GetAvailableActions().Keys),
            "Such action does not exist. Please try again."
        );

        _mainDicts.GetAvailableActions()[userChoice].action.Invoke();
    }
}
