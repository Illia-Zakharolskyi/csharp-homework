// .Net 9.0
// Data
using CardGame.Data.UserProfile;
using System.Text.Json;
namespace CardGame.src.Application.Storages;

internal class UserChoicesStorage
{
    private readonly string? _path;

    public UserChoicesStorage()
    {
        _path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CardGame",
            "UserChoices.json"
        );
    }

    public void Save(UserChoices choices)
    {
        if (_path == null)
        {
            Console.WriteLine("The way to the save file is not set.");
            return;
        }

        _ = Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(choices, options);

        try
        {
            File.WriteAllText(_path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }
    public UserChoices Load()
    {
        if (_path == null)
        {
            Console.WriteLine("The path to the load file is not set.");
            return new UserChoices();
        }

        if (!File.Exists(_path))
        {
            return new UserChoices();
        }

        string json;
        try
        {
            json = File.ReadAllText(_path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            return new UserChoices();
        }

        UserChoices res;
        try
        {
            res = JsonSerializer.Deserialize<UserChoices>(json) ?? new UserChoices();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
            return new UserChoices();
        }

        return res;
    }
}