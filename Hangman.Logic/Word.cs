namespace Hangman.Logic;
public class Word
{
    public string WordToGuess { get; private set; }
    public char[] GuessedLetters { get; private set; }
    private int _remainingLetterCount;
    public int NumberOfGuessedLetters { get; private set; }
    public event Action? WordHasChanged;
    public int RemainingLetterCount
    {
        get
        {
            int count = 0;

            for (int i = 0; i < GuessedLetters.Length; i++)
            {
                if (GuessedLetters[i] == '_')
                {
                    count++;
                }
            }
            _remainingLetterCount = count;
            return _remainingLetterCount;
        }
    }

    public Word(string word)
    {
        WordToGuess = word.ToUpper();
        GuessedLetters = new string('_', WordToGuess.Length).ToCharArray();
    }

    public override string ToString()
    {
        return WordToGuess;
    }

    public bool CompletelyGuessed()
    {
        return new string(GuessedLetters) == WordToGuess;
    }

    public bool CheckGuess(char letter)
    {
        NumberOfGuessedLetters = 0;
        bool correctGuess = false;
        for (int i = 0; i < WordToGuess.Length; i++)
        {
            if (WordToGuess[i] == char.ToUpper(letter))
            {
                GuessedLetters[i] = letter;
                correctGuess = true;
                NumberOfGuessedLetters++;
            }
        }
        WordHasChanged.Invoke();
        return correctGuess;
    }

    public bool CheckCompleteGuess(string word)
    {
        bool completeGuess = false;
        
        if (word.Length < WordToGuess.Length || word.Length > WordToGuess.Length)
        {
            Console.WriteLine("That word was longer/shorter than the word your trying to guess. Try again next time.");
            return completeGuess;
        }

        string guess = word.ToUpper();

        for (int i = 0; i < WordToGuess.Length; i++)
        {
            if (WordToGuess[i] == guess[i])
            {
                GuessedLetters[i] = guess[i];
                completeGuess = true;
            }
        }

        WordHasChanged?.Invoke();
        return completeGuess;
    }
}