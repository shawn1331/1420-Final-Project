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

    public bool CompletelyGuessed()//REQ#1.6.3
    {
        return new string(GuessedLetters) == WordToGuess;
    }

    public bool CheckGuess(char letter)//REQ#1.4.3  
    {
        NumberOfGuessedLetters = 0;
        bool correctGuess = false;
        for (int i = 0; i < WordToGuess.Length; i++)
        {
            if (WordToGuess[i] == char.ToUpper(letter))
            {
                GuessedLetters[i] = char.ToUpper(letter);
                correctGuess = true;
                NumberOfGuessedLetters++;
            }
        }
        WordHasChanged?.Invoke(); // REQ#3.1.3
        return correctGuess;
    }

    public bool CheckCompleteGuess(string word)// REQ#1.5.3 
    {
        bool completeGuess = false;

        if (word.Length < WordToGuess.Length || word.Length > WordToGuess.Length)
        {
            throw new InvalidOperationException("Your guess was of incorrect length.");
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

        WordHasChanged?.Invoke(); // REQ#3.1.3
        return completeGuess;
    }
}