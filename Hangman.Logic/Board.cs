namespace Hangman.Logic;
public class Board : IBoard
{
    public int MaxMissedGuesses {get; private set;}
    public List<char> _incorrectGuesses;


    public Board(int maxMissedGuesses = 6)
    {
        MaxMissedGuesses = maxMissedGuesses;
        _incorrectGuesses = new();
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

    public bool HasGuesses()
    {
        return MaxMissedGuesses > 0;
    }

    public void AddToMissedGuesses(char guess)
    {
        _incorrectGuesses.Add(guess);
        MaxMissedGuesses--;
    }

    public void ShowPastGuesses()
    {
        Console.Write("These are the letters you have already tried: ");

        for (int i = 0; i < _incorrectGuesses.Count; i++)
        {
            if (i == _incorrectGuesses.Count - 1)
            {
                Console.Write(_incorrectGuesses[i]);
            }
            Console.Write(_incorrectGuesses[i] + ", ");
        }
    }
}