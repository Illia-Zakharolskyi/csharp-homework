// .Net 9.0

// Data
using CardGame.Data.UserProfile;
using CardGame.src.Application.Storages;
// Application
using CardGame.src.Application.Utilities.Validators;
// Domain

// Infastructure
using CardGame.src.Infastructure.DTO;
using CardGame.src.Infastructure.Loaders;
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Interfaces;
// UI
using CardGame.src.UI.Models;

namespace CardGame.src.UI.Menus;

internal class CharacterSelectionMenu : Menu, IMenu
{
    private readonly JsonLoader _loader = new();
    internal CharacterSelectionMenu(MenuDispatcher dispatcher, UserChoices userChoices, UserChoicesStorage userChoicesStorage) : base(dispatcher, userChoices, userChoicesStorage)
    {

    }

    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>()
        {
            { 0, ("exit", () => _dispatcher.PopMenu()) },
            { 1, ("choose character", () => ChooseCharacter()) }
        };
    }

    private void ChooseCharacter()
    {
        Console.Clear();

        string fullCharacterListPath = Path.Combine(AppContext.BaseDirectory, "Resources/JsonFiles/Lists/CharactersList.json");

        List<CharacterInfo> characterPaths = _loader.Load<CharacterInfo>(fullCharacterListPath);
        Dictionary<string, CharacterInfo> characterMap = characterPaths.ToDictionary(c => c.Name, c => c);

        Console.WriteLine($"{"Character",-10} | {"Number"}");
        Console.WriteLine(new string('-', 40));

        foreach (var key in characterMap.Keys.Select((name, index) => (name, index)))
        {
            Console.WriteLine($"{key.name,-10} | {key.index + 1}");
        }

        Console.WriteLine(new string('-', 40));

        int userChoice = InetegerValidator.ReadInteger(
            promptMessage: "Enter the number of the character you want to choose: ",
            invalidInputMessage: "Invalid input, please enter a whole number.",
            allowedAnswers: Enumerable.Range(1, characterMap.Count).ToList(),
            invalidChoiceMessage: "That number is not available, please enter a valid number."
        );

        string selectedCharacterName = characterMap.Keys.ElementAt(userChoice - 1);

        _userChoices.SelectedCharacterName = selectedCharacterName;
        _userChoicesStorage.Save(_userChoices);

        Console.WriteLine($"You have selected the character: {selectedCharacterName}");
        _ = Console.ReadKey(true);
        return;
    }
}