using MagicCrystal.CrystalHeart.Helpers.Factories;
using MagicCrystal.UserProfile;

namespace MagicCrystal.PresentationLayer;

internal static class UserInputHandler
{
    internal static void StartHandle(User user)
    {
        Console.WriteLine("hello! you can ask me a question, and I will answer it!*");
        Console.WriteLine("*This is not an AI, the answer is randomly generated");
        Console.WriteLine("also: you can enter the command 'exit' to exit, and 'change style' to change the crystal's response style!");
        Console.Write("> ");

        string? input = Console.ReadLine();

        var availablePrograms = CommandFactory.Create(user);
        if (availablePrograms.ContainsKey(input ?? string.Empty))
        {
            availablePrograms[input!].Execute();
        }
    }
}
