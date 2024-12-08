namespace Hangman.Logic;
public class Board : IBoard  // REQ#2.2.1
{
    public int MaxMissedGuesses { get; private set; }

    public List<char> BoardIncorrectGuesses { get; private set; }
    public string[] Stages {get;} = {
@"______
|    | 
|
|
|
|
+----",
@"______
|    |
|    O
|
|
|
+----",
@"______
|    |  
|    O
|    |
|  
|
+----",
@"______
|    |
|    O
|    |
|   /
|
+----",
@"______
|    |
|    O
|    |
|   / \
|
+----",
@"______
|    |
|    O
|    |\
|   / \
|
+----",
@"______
|    |
|    O
|   /|\
|   / \
|
+----"
};
    public Board()
    {
        BoardIncorrectGuesses = new();
        MaxMissedGuesses = 6;
    }

    public bool BoardHasGuesses() => MaxMissedGuesses > 0;

    public void AddToBoardMissedGuesses(char guess)//REQ#1.3.3
    {
        BoardIncorrectGuesses.Add(char.ToUpper(guess));
        MaxMissedGuesses -= 1;
    }

    public void ShowBoardPastGuesses()
    {
        Console.Write("These are the letters you have already tried: ");

        for (int i = 0; i < BoardIncorrectGuesses.Count; i++)
        {
            if (i == BoardIncorrectGuesses.Count - 1)
            {
                Console.Write(BoardIncorrectGuesses[i]);
            }
            else
            Console.Write(BoardIncorrectGuesses[i] + ", ");
        }
        Console.WriteLine();
    }
    public string GetHangedMan()
    {
        return MaxMissedGuesses switch
        {
            6 => Stages[0],
            5 => Stages[1],
            4 => Stages[2],
            3 => Stages[3],
            2 => Stages[4],
            1 => Stages[5],
            0 => Stages[6],
            _ => throw new ArgumentException($"Invalid number of missed guesses {MaxMissedGuesses}")
        };
    }

    public void PrintWord(Word word)
    {
        Console.SetCursorPosition(0,8);
        for (int i = 0; i < word.GuessedLetters.Length; i++)
        {
            Console.Write(word.GuessedLetters[i] + " ");
        }
    }

    public void PrintPoints(Player player)
    {
        Console.SetCursorPosition(0,10);
        Console.WriteLine(player.ToString());
        Console.WriteLine($"You have {MaxMissedGuesses} guesses remaining");
    }
}