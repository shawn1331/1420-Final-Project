using Hangman.Logic;

public static class Lobby
{
    public static event Action? UpdateGameList;
    public static List<Game> Games = new();

    public static void FireUpdateGameList()
    {
        UpdateGameList?.Invoke();
    }
}