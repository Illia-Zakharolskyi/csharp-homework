using OOPLearning.Application.Helpers.Dictionaries;
using SimpleAssistant.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace OOPLearning.UI;

internal static class MainHandler
{
    internal static void StartHandle()
    {
        int userNumber = IntegerValidator.ReadInteger("enter presentation number: ", "invalid input", MainDicts.availableActions.Keys.ToList(), "invalid number");
        Console.Clear();
        MainDicts.availableActions[userNumber].action();
    }
}
