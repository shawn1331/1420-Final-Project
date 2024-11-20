namespace Hangman.Logic;
public class Board : IBoard  // inheritence
{
    public int MaxMissedGuesses { get; private set; }


    public Board()
    {
    }   

    public bool BoardHasGuesses() => MaxMissedGuesses > 0;
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