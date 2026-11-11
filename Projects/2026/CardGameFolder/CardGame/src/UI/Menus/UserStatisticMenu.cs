// .Net 9.0

// Data
using CardGame.Data.UserProfile;

// Application
using CardGame.src.Application.Storages;

// UI
using CardGame.src.UI.Dispatchers;
using CardGame.src.UI.Interfaces;
using CardGame.src.UI.Models;

namespace CardGame.src.UI.Menus;

internal class UserStatisticMenu : Menu, IMenu
{
    private readonly UserStatisticsStorage _userStatisticsStorage;
    private UserStatistics _userStatistics => _userStatisticsStorage.Load();

    internal UserStatisticMenu(MenuDispatcher dispatcher, UserChoices userChoices, UserChoicesStorage userChoicesStorage, UserStatisticsStorage userStatisticsStorage)
        : base(dispatcher, userChoices, userChoicesStorage)
    {
        _userStatisticsStorage = userStatisticsStorage;
    }

    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("return", () => _dispatcher.PopMenu()) },
            { 1, ("Show Statistics", () => ShowStatistics())   }
        };
    }

    private void ShowStatistics()
    {
        Console.Clear();

        string Battles = $"Battles: {_userStatistics.GamesPlayed}";

        string PlayerMoves = $"Player Moves: {_userStatistics.UserMovesMade}";
        string BotMoves = $"Bot Moves: {_userStatistics.OpponentMovesMade}";

        string Wins = $"Wins: {_userStatistics.GamesWon}";
        string Losses = $"Losses: {_userStatistics.GamesLost}";

        string PlayerDamage = $"Total Damage Dealt by Player: {_userStatistics.TotalPlayerDamageDealt}";
        string BotDamage = $"Total Damage Dealt by Bot: {_userStatistics.TotalOpponentDamageDealt}";

        string[] strings = new string[]
        {
            Battles,
            "",
            PlayerMoves,
            BotMoves,
            "",
            Wins,
            Losses,
            "",
            PlayerDamage,
            BotDamage,
        };

        foreach (var str in strings)
        {
            int left = Math.Max(0, Console.WindowWidth / 2 - str.Length / 2);
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(str);
        }
    }
}
