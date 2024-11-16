namespace Hangman.Logic;
public class Word
{
    private string _wordToGuess;
    public char[] GuessedLetters { get; private set; }
    private int _remainingLetterCount;
    public int RemainingLetterCount
    {
        get
        {
            return _remainingLetterCount;
        }

        private set
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
        }

    }

    public Word(string word)
    {
        _wordToGuess = word.ToUpper();
        GuessedLetters = new string('_', _wordToGuess.Length).ToCharArray();
    }

    public override string ToString()
    {
        return _wordToGuess;
    }

    public bool CompletelyGuessed()
    {
        return new string(GuessedLetters) == _wordToGuess;
    }

    public bool CheckGuess(char letter)
    {
        bool correctGuess = false;
        for (int i = 0; i < _wordToGuess.Length; i++)
        {
            if (_wordToGuess[i] == char.ToUpper(letter))
            {
                GuessedLetters[i] = letter;
                correctGuess = true;
            }
        }
        return correctGuess;
    }

    public bool CheckCompleteGuess(string word)
    {
        Console.WriteLine("Would you like to try to guess the rest of the word? y/n");
        char guessRestOfWord = Console.ReadKey().KeyChar;

        if (guessRestOfWord == 'y')
        {
            bool completeGuess = false;
            if (word.Length < _wordToGuess.Length)
            {
                return completeGuess;
            }

            string guess = word.ToUpper();

            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                if (_wordToGuess[i] == guess[i])
                {
                    GuessedLetters[i] = guess[i];
                    completeGuess = true;
                }
            }
            return completeGuess;
        }
        else
        {
            return false;
        }
    }
}