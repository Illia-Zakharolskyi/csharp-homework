// .NET9.0

// Application
using Lesson_03_12_2025.Application.Managers;

namespace Lesson_03_12_2025.Application.Helpers.Dictionaries;

internal class MainDicts
{
    private readonly ElectronicDictionaryManager _dictionaryManager;

    internal MainDicts(ElectronicDictionaryManager dictionaryManager)
    {
        _dictionaryManager = dictionaryManager;
    }

    internal Dictionary<int, (string description, Action action)> GetAvailableActions()
    {
        return new Dictionary<int, (string description, Action action)>()
        {
            { 0, ("Exit", () => Environment.Exit(0)) },
            { 1, ("Add word and definition", () => _dictionaryManager.AddEntry()) },
            { 2, ("Delete word", () => _dictionaryManager.RemoveEntry()) },
            { 3, ("Update definition for word", () => _dictionaryManager.UpdateEntry()) },
            { 4, ("Find definition for word", () => _dictionaryManager.SearchEntry()) },
            { 5, ("Show all words with definitions", () => _dictionaryManager.ShowAllEntries()) },
        };
    }
}
