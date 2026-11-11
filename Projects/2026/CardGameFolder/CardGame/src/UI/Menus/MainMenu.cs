// .Net 9.0

// Data
using CardGame.Data.UserProfile;
// Application
using CardGame.src.Application.Managers;
using CardGame.src.Application.Storages;
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Interfaces;
// Domain

// Infastructure

// UI
using CardGame.src.UI.Models;

namespace CardGame.src.UI.Menus;

internal class MainMenu : Menu, IMenu
{
    private readonly CharacterSelectionMenu _characterSelectionMenu;
    private readonly UserStatisticMenu _userStatisticMenu;

    private readonly GameManager _gameManager;

    internal MainMenu(MenuDispatcher dispatcher, GameManager gameManager, UserChoices userChoices, UserChoicesStorage userChoicesStorage, UserStatisticsStorage userStatisticsStorage)
        : base(dispatcher, userChoices, userChoicesStorage)
    {
        _gameManager = gameManager;
        _characterSelectionMenu = new CharacterSelectionMenu(dispatcher, userChoices, _userChoicesStorage);
        _userStatisticMenu = new UserStatisticMenu(dispatcher, userChoices, userChoicesStorage, userStatisticsStorage);
    }

    public void Display()
    {
        base.Display(GetActionMap());
    }
    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("exit", () => Environment.Exit(0)) },
            { 1, ("Start Battle", () => StartBattleAction()) },
            { 2, ("Choose Character", () => _dispatcher.PushMenu(_characterSelectionMenu)) },
            { 3, ("Statistics", () => _dispatcher.PushMenu(_userStatisticMenu)) }
        };
    }
    private void StartBattleAction()
    {
        if (_userChoices.SelectedCharacterName == null)
        {
            Console.WriteLine("Please choose a character first!");
            _ = Console.ReadKey(true);
            return;
        }

        _gameManager.StartBattle(_userChoices);
    }
}