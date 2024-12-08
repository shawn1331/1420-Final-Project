namespace Hangman.Logic;
public class Game
{
    public Player? Player1 { get; private set; }
    public Player? Player2 { get; private set; }
    public Player? CurrentPlayer { get; private set; }
    public Word Word { get; private set; }
    public Board Board { get; private set; }
    public static Random _random = new();
    public delegate char GetGuessDelegate(); // delegate creation
    public delegate string GetCompleteGuessDelegate();  // delegate creation
    public delegate char GetInputDelegate();
    public event Action? GameStateChanged;
    public event Action? GameReset;

    public Game()
    {

    }

    public Game(string wordToGuess)
    {
        Word = new Word(wordToGuess);
        Board = new();
    }
    public Game(Player p1, Player p2, string wordToGuess)
    {
        Player1 = p1;
        Player2 = p2;
        Word = new Word(wordToGuess);
        CurrentPlayer = Player1;
        Board = new();
    }

    public void FireGameStateChanged() => GameStateChanged?.Invoke();

    public void PlayGame()
    {
        string wholeWordGuess = "";
        char guess = ' ';
        char wantsToGuessWord = ' ';

        while (Board.BoardHasGuesses() && !Word.CompletelyGuessed())
        {
            Console.Clear();
            string currentHangman = Board.GetHangedMan();
            Console.SetCursorPosition(0,0);
            Console.WriteLine(currentHangman);
            Board.PrintWord(Word);
            Board.PrintPoints(CurrentPlayer);

            if (Board.BoardIncorrectGuesses.Count != 0)
                Board.ShowBoardPastGuesses();

            int missingLetterCount = Word.RemainingLetterCount;

            if (CurrentPlayer.GetType() == typeof(HumanPlayer) && Word.RemainingLetterCount <= Word.GuessedLetters.Length - 3)
                wantsToGuessWord = CurrentPlayer.GetUserInput();

            if (wantsToGuessWord == 'y')
            {
                wholeWordGuess = CurrentPlayer.MakeCompleteGuess();

                if (Word.CheckCompleteGuess(wholeWordGuess))
                {
                    Console.WriteLine("You guessed the rest of the word, Good Job!");
                    CurrentPlayer.UpdateScore(missingLetterCount * 10);
                }
            }
            else
            {
                guess = CurrentPlayer.MakeGuess();

                if (Word.CheckGuess(guess))
                {
                    Console.WriteLine("Correct guess!");
                    CurrentPlayer.UpdateScore(5 * Word.NumberOfGuessedLetters);
                }
                else
                {
                    Console.WriteLine("The word does not contain that letter.");
                    Board.AddToBoardMissedGuesses(guess);
                }
            }

            if (!Word.CompletelyGuessed())
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;

            System.Threading.Thread.Sleep(1500);
        }

        if (!Word.CompletelyGuessed() && !Board.BoardHasGuesses())
        {
            Console.WriteLine($"Game Over! The word was {Word}");
        }
        else if (Word.CompletelyGuessed())
        {
            Console.WriteLine($"Congratulations {CurrentPlayer.Name} you won! You have {CurrentPlayer.Score} points. The word was {Word}");
        }
    }

    public static string SelectWordToGuess()
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

    public void ResetGameState(string wordToGuess)
    {
        Board = new();
        Player1?.ResetPlayerScore();
        Player2?.ResetPlayerScore();
        CurrentPlayer = Player1;
        Word = new(wordToGuess);
        GameReset?.Invoke();
    }

    public void Join(Player player)
    {
        if (Player1 == null)
        {
            Player1 = player;
            Player1.Word = new Word(Word.WordToGuess);
        }
        else if (Player2 == null)
        {
            Player2 = player;
            Player2.Word = new Word(Word.WordToGuess);
        }
        else
            throw new GameFullException();

        GameStateChanged?.Invoke();
    }
}