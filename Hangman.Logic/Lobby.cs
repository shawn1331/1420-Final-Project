namespace Hangman.Logic;

public static class Lobby  // use of a static class
{
    public static event Action? UpdateGameList;
    public static Dictionary<string, Game?> GamesList { get; private set; } = new();
    public static IEnumerable<(string Name, Game? Game)> ActiveGames => GamesList
        .Where(x => x.Value.Player2 is not null && x.Value.Word.CompletelyGuessed() is false)
        .Select(x => (x.Key, x.Value));

    public static IEnumerable<string> OpenGames => GamesList
        .Where(x => x.Value.Player2 == null)
        .Select(x => x.Key);

    public static bool CreateGame(string gameName)
    {
        Game newGame = new();
        bool gameAdded = GamesList.TryAdd(gameName, newGame);
        if (gameAdded)
        {
            UpdateGameList?.Invoke();
            newGame.GameStateChanged += () => UpdateGameList?.Invoke();
        }
        return gameAdded;
    }

    public static Game? GetGame(string gameName)
    {
        return GamesList.ContainsKey(gameName) ? GamesList[gameName] : null;
    }

    public static void FireUpdateGameList()  // static method
    {
        UpdateGameList?.Invoke();
    }
}