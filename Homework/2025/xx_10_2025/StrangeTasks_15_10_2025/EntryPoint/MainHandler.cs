using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.EntryPointDicts;
using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

namespace StrangeTasks_15_10_2025.EntryPoint;

internal static class MainHandler
{
    internal static void StartHanlde()
    {
        int userOption = IntegersHelper.ReadInteger("Enter the option: ", "It is not an integer or the value is too large", MainDicts.entryDict.Keys.ToList(), "There is no such an option");
        Console.Clear();
        MainDicts.entryDict[userOption].program.Run();
    }
}
