namespace Hangman.Logic;
public class Board : IBoard  // inheritence/ implementing the interface
{
    public int MaxMissedGuesses { get; private set; }

    public List<char> IncorrectGuesses { get; private set; }
    public Board()
    {
        IncorrectGuesses = new();
        MaxMissedGuesses = 6;
    }

    public bool BoardHasGuesses() => MaxMissedGuesses > 0;

    public void AddToBoardMissedGuesses(char guess)
    {
        IncorrectGuesses.Add(guess);
        MaxMissedGuesses--;
    }
    public void PrintHangedMan()
    {

    }

    public void PrintWord(Word word)
    {
        // Console.SetCursorPosition();
        for (int i = 0; i < word.GuessedLetters.Length; i++)
        {
            Console.Write(word.GuessedLetters[i]);
        }
    }

    public void PrintPoints(Player player)
    {
        // Console.SetCursorPosition();
        Console.WriteLine(player.ToString());
    }
}