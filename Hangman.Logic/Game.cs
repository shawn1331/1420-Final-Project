namespace Hangman.Logic;
public class Game
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private Word _word;
    private Board _board;
    public static Random _random;
    public delegate char GetGuessDelegate();
    public delegate string GetCompleteGuessDelegate();
    private int NumberOfPlayers { get; set; }
    private string GameName { get; set; }

public Game()
{

}
    public Game(Player p1, Player p2, string wordToGuess, int maxGuesses)
    {
        _player1 = p1;
        _player2 = p2;
        _word = new Word(wordToGuess);
        _board = new Board(maxGuesses);
        _currentPlayer = _player1;
        _random = new();
    }

    public void PlayGame(char letter)
    {

    }

    public string SelectWordToGuess()
    {
        return _random.Next(0, 21) switch
        {
            0 => "unorthodox",
            1 => "conscientious",
            2 => "vivacious",
            3 => "indispensable",
            4 => "detrimental",
            5 => "vicarious",
            6 => "derivative",
            7 => "epiphany",
            8 => "inspirational",
            9 => "comprehension",
            10 => "luminaire",
            11 => "nostalgic",
            12 => "evocative",
            13 => "recession",
            14 => "plagiarism",
            15 => "stagnation",
            16 => "relinquish",
            17 => "abdicated",
            18 => "egregious",
            19 => "acquiesce",
            20 => "requiem"
        };
    }
}
