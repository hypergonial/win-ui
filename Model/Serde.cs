namespace Persistence;

using System.Diagnostics;
using System.Text.Json;

using Model;


/// <summary>
/// SERialize/DEserialize the game model.
/// </summary>
public static class Serde
{
    private static string GetSavePath()
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NineMensMorris", "saves");
    }

    private static void CreateSavePath()
    {
        Directory.CreateDirectory(GetSavePath());
    }

    /// <summary>
    /// Serialize the game model to a JSON string.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static string Serialize(Game game) {
        return JsonSerializer.Serialize(game);
    }

    /// <summary>
    /// Deserialize the game model from a JSON string.
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static Game? Deserialize(string json) {
        return JsonSerializer.Deserialize<Game>(json);
    }

    /// <summary>
    /// Serialize the game model and then save it to a file.
    /// </summary> 
    /// <param name="game"></param>
    /// <param name="name"></param>
    public static void Save(Game game, string name)
    {
        CreateSavePath();
        string json = Serialize(game);
        File.WriteAllText(Path.Combine(GetSavePath(), $"{name}.json"), json);
    }

    /// <summary>
    /// Load a game model from a file and deserialize it.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Game? Load(string name)
    {
        CreateSavePath();
        string json = File.ReadAllText(Path.Combine(GetSavePath(), $"{name}.json"));
        Game? output = Deserialize(json);
        return output;
    }

    /// <summary>
    /// Delete a save file.
    /// </summary>
    /// <param name="name"></param>
    public static void Delete(string name)
    {
        CreateSavePath();
        File.Delete(Path.Combine(GetSavePath(), $"{name}.json"));
    }

    /// <summary>
    /// Get a list of all save files.
    /// </summary>
    /// <returns></returns>
    public static string[] GetSaves()
    {
        CreateSavePath();
        return Directory.GetFiles(GetSavePath()).Where(f => f.EndsWith(".json")).Select(f => Path.GetFileName(f.Remove(f.Length - 5))).ToArray();
    }
}
