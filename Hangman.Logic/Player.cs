public class Player : IPlayer
{
    public int Score { get; private set; }
    public char Guess { get; private set; }
    public string Name { get; set; }
    List<char> _pastGuesses;

    public Player(string name)
    {
        Name = name;
        _pastGuesses = new();
    }

    public void AddToGuesses(char guess)
    {
        _pastGuesses.Add(guess);
    }

    public void ShowPastGuesses()
    {
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



}