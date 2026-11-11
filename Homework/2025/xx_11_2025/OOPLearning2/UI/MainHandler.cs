using OOPLearning2.Application.Routing.Dictionaries;
using OOPLearning2.Application.Utilitites.Validators;

namespace OOPLearning2.UI;

internal static class MainHandler
{
    internal static void Start()
    {
        int userNumber = IntegerValidator.ReadInteger("Enter the number: ", "invalid input", DemoActionMap.availableActions.Keys.ToList(), "invalid number");
        Console.Clear();
        DemoActionMap.availableActions[userNumber].action();
    }
}
