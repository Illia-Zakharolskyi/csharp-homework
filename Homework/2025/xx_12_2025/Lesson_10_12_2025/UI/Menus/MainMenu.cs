// .NET 9.0

// Application


// UI
using Lesson_10_12_2025.UI.Dispatchers;
using Lesson_10_12_2025.UI.Interfaces;
using Lesson_10_12_2025.UI.Models;

namespace Lesson_10_12_2025.UI.Menus;

internal class MainMenu : Menu, IMenu
{
    public void Display()
    {
        base.Display(GetActionMap());
    }

    public override Dictionary<int, (string description, Action action)> GetActionMap()
    {
        Task1Menu task1Menu = new();
        Task2Menu task2Menu = new();
        Task3Menu task3Menu = new();
        Task4Menu task4Menu = new();
        Task5Menu task5Menu = new();
        Task6Menu task6Menu = new();
        Task7Menu task7Menu = new();


        return new Dictionary<int, (string description, Action action)>
        {
            { 0, ("Exit", () => Environment.Exit(0)) },
            { 1, ("Refactored Task 1", () => MenuDispatcher.Run(task1Menu)) },
            { 2, ("Refactored Task 2", () => MenuDispatcher.Run(task2Menu)) },
            { 3, ("Refactored Task 3", () => MenuDispatcher.Run(task3Menu)) },
            { 4, ("Refactored Task 4", () => MenuDispatcher.Run(task4Menu)) },
            { 5, ("Refactored Task 5", () => MenuDispatcher.Run(task5Menu)) },
            { 6, ("Refactored Task 6", () => MenuDispatcher.Run(task6Menu)) },
            { 7, ("Refactored Task 7", () => MenuDispatcher.Run(task7Menu)) },
        };
    }
}