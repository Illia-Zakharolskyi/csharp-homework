using OOPLearning3.Application.Routing;
using OOPLearning3.Application.Utilities.Validators;

namespace OOPLearning3.UI;

internal static class MainHandler
{
    internal static void Start()
    {
        int userAction = IntegerValidator.ReadInteger("Enter the number of the action you want to perform \n> ", "This is not a number, try again", MainDicts.availableActions.Keys.ToList(), "Sorry, this action number does not exist yet. Try again");
        Console.Clear();
        MainDicts.availableActions[userAction].action.Invoke();
    }
}
