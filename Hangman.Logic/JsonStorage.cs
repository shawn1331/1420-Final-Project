using Hangman.Logic;
using System.Text.Json;
using System.Xml.Schema;
public class JsonStorage
{
    private readonly object fileLock = new object();
    private string filePath = "C:\\Users\\shawn\\1415code\\Fall 2024 1420 Code\\Final-Project\\1420-Final-Project\\Hangman.Web\\wwwroot\\data\\scoreboard.json";
    public JsonStorage()
    {

    }

    public List<ScoreBoard> GetScoreBoard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ScoreBoard>>(json);
        }
        else
            return [];
    }

    public void AddScore(Player player)
    {
        lock (fileLock)
        {
            var scores = GetScoreBoard();
            scores.Add(new ScoreBoard(player.Name, player.Score));
            string json = JsonSerializer.Serialize(scores);
            File.WriteAllText(filePath, json);
        }
    }
}