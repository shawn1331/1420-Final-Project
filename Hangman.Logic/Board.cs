namespace Hangman.Logic;
public class Board : IBoard  // REQ#2.2.1
{
    public int MaxMissedGuesses { get; private set; }

    public List<char> IncorrectGuesses { get; private set; }
    public Board()
    {
        IncorrectGuesses = new();
        MaxMissedGuesses = 6;
    }

    public bool BoardHasGuesses() => MaxMissedGuesses > 0;

    public void AddToBoardMissedGuesses(char guess)//REQ#1.3.3
    {
        IncorrectGuesses.Add(guess);
        MaxMissedGuesses -= 1;
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