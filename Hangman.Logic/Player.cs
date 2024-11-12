namespace Hangman.Logic;
public abstract class Player : IPlayer
{
    public int Score { get; private set; }
    public char Guess { get; private set; }
    public string Name { get; set; }
    List<char> _pastGuesses;
    protected Game.GetGuessDelegate GetGuess; 

    public Player(string name, Game.GetGuessDelegate getGuess)
    {
        Name = name;
        Score = 0;
        _pastGuesses = new();
        GetGuess = getGuess;
    }

    public void AddToGuesses(char guess)
    {
        _pastGuesses.Add(guess);
    }

    public void ShowPastGuesses()
    {
        Console.Write("These are the letters you have already tried: ");

        for (int i = 0; i < _pastGuesses.Count; i++)
        {
            if (i == _pastGuesses.Count - 1)
            {
                Console.Write(_pastGuesses[i]);
            }
            Console.Write(_pastGuesses[i] + ", ");
        }
    }

    public void UpdateScore(int points)
    {
        Score += points;
        Console.WriteLine($"{Name} has {Score} points");
    }

    public abstract char MakeGuess();



}