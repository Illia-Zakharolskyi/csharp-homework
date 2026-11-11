// .Net 9.0
using System.Text.Json;

// Domain

namespace CardGame.src.Infastructure.Loaders;

internal class JsonLoader
{
    internal List<T> Load<T>(string filePath)
        where T : class
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            throw new ArgumentException("Invalid file path", nameof(filePath));
        }

        string json = File.ReadAllText(filePath);
        List<T>? items = JsonSerializer.Deserialize<List<T>>(json);

        return items ?? throw new ArgumentException($"Invalid data format for creating {typeof(T).Name}: {filePath}");
    }
}