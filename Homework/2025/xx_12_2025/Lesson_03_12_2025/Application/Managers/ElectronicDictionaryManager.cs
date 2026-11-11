// .NET9.0


// Application
using Lesson_03_12_2025.Application.Utilities.Validators;

// Domain
using Lesson_03_12_2025.Domain.Models;

namespace Lesson_03_12_2025.Application.Managers;

internal class ElectronicDictionaryManager
{
    private readonly List<ElectronicDictionaryEntry>? _entries;
    private bool _isFileChanged = false;

    private void MarkAsNeedToSaveFile() => _isFileChanged = true;
    internal bool NeedToSaveFile() => _isFileChanged;
    internal void MarkFileAsSaved() => _isFileChanged = false;

    internal ElectronicDictionaryManager(List<ElectronicDictionaryEntry> entries)
    {
        _entries = entries ?? new List<ElectronicDictionaryEntry>();
    }

    internal void AddEntry()
    {
        string word = StringValidator.ReadString("Enter word: ", "Invalid value for word");
        string definition = StringValidator.ReadString("Enter definition: ", "Invalid value for definition");

        _entries!.Add(new ElectronicDictionaryEntry(word, definition));

        Console.WriteLine("Word and definition added!");
        MarkAsNeedToSaveFile();
    }
    internal void RemoveEntry()
    {
        string word = StringValidator.ReadString("Enter word to delete: ", "Invalid value for word");

        var entry = _entries!.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        if (entry != null)
        {
            _ = _entries!.Remove(entry);
            Console.WriteLine("Word deleted!");
            MarkAsNeedToSaveFile();
            return;
        }

        Console.WriteLine("Word not found");
    }
    internal void UpdateEntry()
    {
        string word = StringValidator.ReadString("Enter word for definition update: ", "Invalid value for word");
        string newDefinition = StringValidator.ReadString("Enter new definition: ", "Invalid value for definition");

        var entry = _entries!.FirstOrDefault(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        if (entry != null)
        {
            entry.Definition = newDefinition;
            Console.WriteLine("Definition updated!");
            MarkAsNeedToSaveFile();
            return;
        }

        Console.WriteLine("Word not found");
    }
    internal void SearchEntry()
    {
        string word = StringValidator.ReadString("Enter word for search: ", "Invalid value for word");

        if (_entries!.Count == 0)
        {
            Console.WriteLine("Dictionary is empty");
            return;
        }

        if (!_entries.Any(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Word not found");
            return;
        }

        var entry = _entries.First(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Definition for word '{entry.Word}': {entry.Definition}");
    }
    internal void ShowAllEntries()
    {
        if (_entries!.Count == 0)
        {
            Console.WriteLine("File is empty and there is nothing to display");
            return;
        }

        Console.WriteLine($"{"Word",-5} | Definition");

        foreach (var entry in _entries)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{entry.Word,-5} | {entry.Definition}");
        }

        Console.WriteLine(new string('-', 30));
    }
    internal List<ElectronicDictionaryEntry> GetAllEntries()
    {
        return _entries!;
    }
}