namespace Hangman.Logic;

public static class Lobby  // use of a static class
{
    public static event Action? LobbyChanged; // events 
    public static Dictionary<string, Game?> GamesList { get; private set; } = new(); // properties
    public static IEnumerable<(string Name, Game? Game)> ActiveGames => GamesList  // use of method call syntax for Linq
        .Where(x => x.Value?.Player2 is not null && x.Value?.Player1.Word.CompletelyGuessed() is false && x.Value?.Word.CompletelyGuessed() is false)
        .Select(x => (x.Key, x.Value));

    public static IEnumerable<string> OpenGames => GamesList    // use of method call syntax for Linq
        .Where(x => x.Value?.Player2 == null)
        .Select(x => x.Key);

    public static bool CreateGame(string gameName, string wordToGuess) // static method
    {
        Game newGame = new(wordToGuess);
        bool gameAdded = GamesList.TryAdd(gameName, newGame);
        if (gameAdded)
        {
            LobbyChanged?.Invoke();
            newGame.GameStateChanged += () => LobbyChanged?.Invoke();
        }
        return gameAdded;
    }

    public static Game? GetGame(string gameName) // static method
    {
        return GamesList.ContainsKey(gameName) ? GamesList[gameName] : null;
    }
}