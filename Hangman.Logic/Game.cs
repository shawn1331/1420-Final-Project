namespace Hangman.Logic;
public class Game
{
    public Player? Player1 {get; private set;}
    public Player? Player2 {get; private set;}
    public Player? CurrentPlayer {get; private set;}
    public Word Word {get; private set;}
    public Board Board {get; private set;}
    public static Random _random;
    public delegate char GetGuessDelegate(); // delegate creation
    public delegate string GetCompleteGuessDelegate();  // delegate creation
    // below is properties used for the Blazor web UI
    public int NumberOfPlayers { get; private set; }
    public int MaxPlayers {get; private set;}
    public string GameName { get; private set; }
    public bool IsFull => NumberOfPlayers == MaxPlayers;
    public event Action? GameStateChanged;
    public event Action? GameReset;

    public Game()
    {

    }
    public Game(Player p1, Player p2, string wordToGuess, int maxMissedGuesses = 6)
    {
        Player1 = p1;
        Player2 = p2;
        Word = new Word(wordToGuess);
        Board = new Board(maxMissedGuesses);
        CurrentPlayer = Player1;
        _random = new();
    }

    public void PlayGame()
    {
        string wholeWordGuess = "";
        char guess = ' ';

        while (Board.HasGuesses() && !Word.CompletelyGuessed())
        {
            Console.Clear();
            Board.PrintHangedMan();
            Board.PrintWord(Word);
            Board.PrintPoints(CurrentPlayer);

            if (Board._incorrectGuesses.Count == 0) ;

            else
                Board.ShowPastGuesses();

            if (Word.RemainingLetterCount < Word.GuessedLetters.Length - 3)
            {
                int letterCount = Word.RemainingLetterCount;
                wholeWordGuess = CurrentPlayer.MakeCompleteGuess();

                if (Word.CheckCompleteGuess(wholeWordGuess))
                {
                    Console.WriteLine("You guessed the rest of the word, Good Job!");
                    CurrentPlayer.UpdateScore(letterCount * 10);
                }
            }
            else
            {
                guess = CurrentPlayer.MakeGuess();

                if (Word.CheckGuess(guess))
                {
                    Console.WriteLine("Correct guess!");
                    CurrentPlayer.UpdateScore(5);
                }
                else
                {
                    Console.WriteLine("The word does not contain that letter.");
                    Board.AddToMissedGuesses(guess);
                }
            }

            if (!Word.CompletelyGuessed())
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;

            System.Threading.Thread.Sleep(1500);
        }

        if (!Word.CompletelyGuessed() && !Board.HasGuesses())
        {
            Console.WriteLine($"Game Over! The word was {Word.ToString()}");
        }
        else if (Word.CompletelyGuessed())
        {
            Console.WriteLine($"Congratulations {CurrentPlayer.Name} you won! You have{CurrentPlayer.Score}");
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
        Board = new();
        word = SelectWordToGuess();
        Player1.ResetPlayerScore(Player1);
        Player2.ResetPlayerScore(Player2);
        CurrentPlayer = Player1;
    }
}
