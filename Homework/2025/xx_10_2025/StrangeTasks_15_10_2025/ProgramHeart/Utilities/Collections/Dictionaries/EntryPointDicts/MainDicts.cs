using StrangeTasks_15_10_2025.ProgramHeart.Core.Interfaces;
using StrangeTasks_15_10_2025.Programs;

namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.EntryPointDicts;

internal static class MainDicts
{
    internal static readonly Dictionary<int, (string description, IRunnable program)> entryDict = new()
    {
        { 0, ("Exit", new ExitProgram()) },
        { 1, ("Juicer", new Juicer()) },
        { 2, ("Computer Master Simulator", new ComputerMasterSimulator()) },
        { 3, ("Magical kitchen", new MagicalKitchen()) },
        { 4, ("time travel", new TimeTravel()) },
        { 5, ("Programmer Quest", new ProgramerQuest()) },
    };
}
