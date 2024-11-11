public class Board :  IBoard
{
    private int _maxGuesses;

    public Board(int maxGuesses)
    {
        _maxGuesses = maxGuesses;
    }
    public void PrintHangedMan()
    {
        
    }

    public void PrintWord()
    {

    }

    public bool HasGuesses()
    {
        return false;
    }
}