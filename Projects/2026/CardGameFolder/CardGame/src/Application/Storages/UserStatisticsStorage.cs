// .Net 9.0
// Data
using CardGame.Data.UserProfile;
using System.Text.Json;

namespace CardGame.src.Application.Storages;

internal class UserStatisticsStorage
{
    private readonly string? _path;

    public UserStatisticsStorage()
    {
        _path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CardGame",
            "UserStatistics.json"
        );
    }

    public void Save(UserStatistics userStatistics)
    {
        if (_path == null)
        {
            Console.WriteLine("The way to the save file is not set.");
            return;
        }

        _ = Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(userStatistics, options);

        try
        {
            File.WriteAllText(_path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public UserStatistics Load()
    {
        if (_path == null)
        {
            Console.WriteLine("The path to the load file is not set.");
            return new UserStatistics();
        }

        if (!File.Exists(_path))
        {
            return new UserStatistics();
        }

        string json;
        try
        {
            json = File.ReadAllText(_path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            return new UserStatistics();
        }

        UserStatistics res;
        try
        {
            res = JsonSerializer.Deserialize<UserStatistics>(json) ?? new UserStatistics();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
            return new UserStatistics();
        }

        return res;
    }
}