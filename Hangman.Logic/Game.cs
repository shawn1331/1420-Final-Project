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
    public Game(Player p1, Player p2, string wordToGuess, int maxMissedGuesses = 6)
    {
        _player1 = p1;
        _player2 = p2;
        _word = new Word(wordToGuess);
        _board = new Board(maxMissedGuesses);
        _currentPlayer = _player1;
        _random = new();
    }

    public void PlayGame()
    {
        string wholeWordGuess = "";
        char guess = ' ';

        while (_board.HasGuesses() && !_word.CompletelyGuessed())
        {
            Console.Clear();
            _board.PrintHangedMan();
            _board.PrintWord(_word);
            _board.PrintPoints(_currentPlayer);

            if (_board._incorrectGuesses.Count == 0) ;

            else
                _board.ShowPastGuesses();

            if (_word.RemainingLetterCount < _word.GuessedLetters.Length - 3)
            {
                int letterCount = _word.RemainingLetterCount;
                wholeWordGuess = _currentPlayer.MakeCompleteGuess();

                if (_word.CheckCompleteGuess(wholeWordGuess))
                {
                    Console.WriteLine("You guessed the rest of the word, Good Job!");
                    _currentPlayer.UpdateScore(letterCount * 10);
                }
            }
            else
            {
                guess = _currentPlayer.MakeGuess();

                if (_word.CheckGuess(guess))
                {
                    Console.WriteLine("Correct guess!");
                    _currentPlayer.UpdateScore(5);
                }
                else
                {
                    Console.WriteLine("The word does not contain that letter.");
                    _board.AddToMissedGuesses(guess);
                }
            }

            if (!_word.CompletelyGuessed())
                _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
                
                System.Threading.Thread.Sleep(1500);
        }

        if (!_word.CompletelyGuessed() && !_board.HasGuesses())
        {
            Console.WriteLine($"Game Over! The word was {_word.ToString()}");
        }
        else if (_word.CompletelyGuessed())
        {
            Console.WriteLine($"Congratulations {_currentPlayer.Name} you won! You have{_currentPlayer.Score}");
        }
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

    public void ResetGameState(string word)
    {
        _board = new();
        word = SelectWordToGuess();
        _player1.ResetPlayerScore(_player1);
        _player2.ResetPlayerScore(_player2);
        _currentPlayer = _player1;
    }
}
