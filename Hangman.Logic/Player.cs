namespace Hangman.Logic;
public abstract class Player : IPlayer
{
    public int Score { get; private set; }
    public char Guess { get; private set; }
    public string Name { get; set; }
    protected Game.GetGuessDelegate GetGuess; 
    protected Game.GetCompleteGuessDelegate GetCompleteGuess;

    public Player(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess)
    {
        Name = name;
        Score = 0;
        GetGuess = getGuess;
        GetCompleteGuess = getCompleteGuess;
    }

    public int UpdateScore(int points)
    {
       return Score += points;
        // Console.WriteLine($"{Name} has {Score} points");
    }

    public override string ToString()
    {
        return $"{Name}, points: {Score}";
    }

    public void ResetPlayerScore(Player player)
    {
        player.Score = 0;
    }

    public abstract char MakeGuess();

    public abstract string MakeCompleteGuess();


}