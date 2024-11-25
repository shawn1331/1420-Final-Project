namespace Hangman.Logic;
public abstract class Player : IPlayer // use of abstract class and inheritence/ implementing the interface
{
    public int Score { get; private set; }
    public string Name { get; set; }
    public int MaxMissedGuesses { get; private set; }
    public Word Word { get; set; }// will be set on joining game
    public List<char> IncorrectGuesses { get; private set; }
    public event Action? HangmanChanged;
    public Game.GetGuessDelegate GetGuess; // delegate variable
    public Game.GetCompleteGuessDelegate GetCompleteGuess;  // delegate variable

    public Player(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess) //creation of delegates of the type I created
    {
        Name = name;
        Score = 0;
        GetGuess = getGuess;
        GetCompleteGuess = getCompleteGuess;
        MaxMissedGuesses = 6;
        IncorrectGuesses = new();
    }


    public bool PlayerHasGuesses() => MaxMissedGuesses > 0;

    public int UpdateScore(int points) => Score += points;

    public void RemoveAGuess()
    {
        MaxMissedGuesses--;
        HangmanChanged?.Invoke();
    }

    public override string ToString()  // polymorphism/ overridden method
    {
        return $"{Name}, points: {Score}";
    }

    public void ResetPlayerScore()
    {
        Score = 0;
    }

    public void AddToMissedGuesses(char guess)
    {
        IncorrectGuesses.Add(guess);
        MaxMissedGuesses--;
        HangmanChanged?.Invoke();
    }

    public void ShowPastGuesses()
    {
        Console.Write("These are the letters you have already tried: ");

        for (int i = 0; i < IncorrectGuesses.Count; i++)
        {
            if (i == IncorrectGuesses.Count - 1)
            {
                Console.Write(IncorrectGuesses[i]);
            }
            Console.Write(IncorrectGuesses[i] + ", ");
        }
    }

    public abstract char MakeGuess();  // abstract method definition

    public abstract string MakeCompleteGuess();  // abstract method definition

}