namespace Hangman.Logic;
public class Board : IBoard
{
    private int _maxGuesses;
    public List<char> _pastGuesses;


    public Board(int maxGuesses)
    {
        _maxGuesses = maxGuesses;
        _pastGuesses = new();
    }
    public void PrintHangedMan()
    {

    }

    public void PrintWord()
    {

    }

    public void PrintPoints()
    {

    }

    public bool HasGuesses()
    {
        return _maxGuesses > 0;
    }

    public void AddToGuesses(char guess)
    {
        _pastGuesses.Add(guess);
        _maxGuesses--;
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
}