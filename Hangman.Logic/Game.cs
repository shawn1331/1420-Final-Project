namespace Hangman.Logic;

public class Game
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private Word _word;
    private Board _board;
    private Random _random;

    public Game(string p1Name, string p2Name, string wordToGuess, int maxGuesses)
    {
        _player1 = new Player(p1Name);
        _player2 = new Player(p2Name);
        _word = new Word(wordToGuess);
        _board = new Board(maxGuesses);
        _currentPlayer = _player1;
        _random = new();
    }

    public void PlayGame()
    {

    }

    public char [] SelectWordToGuess()
    {
        return _random.Next() switch 
        {

        };
    }
}
