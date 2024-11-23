namespace Hangman.Logic;
public abstract class Player : IPlayer // use of abstract class and inheritence
{
    public int Score { get; private set; }
    public string Name { get; set; }
    public int MaxMissedGuesses { get; private set; }
    public Word Word { get; private set; }
    public List<char> IncorrectGuesses { get; private set; }
    public Game.GetGuessDelegate GetGuess; // delegate variable
    public Game.GetCompleteGuessDelegate GetCompleteGuess;  // delegate variable

    public Player(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, string wordToGuess)
    {
        Name = name;
        Score = 0;
        GetGuess = getGuess;
        GetCompleteGuess = getCompleteGuess;
        MaxMissedGuesses = 6;
        IncorrectGuesses = new();
        Word = new(wordToGuess);
    }


    public bool PlayerHasGuesses() => MaxMissedGuesses > 0;

    public int UpdateScore(int points) => Score += points;

    public bool HasGuesses()
    {
        return MaxMissedGuesses > 0;
    }

    public void RemoveAGuess() => MaxMissedGuesses--;

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