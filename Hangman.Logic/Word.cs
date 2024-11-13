namespace Hangman.Logic;
public class Word
{
    private string _wordToGuess;
    private char[] _guessedLetters;
    
    public Word(string word)
    {
        _wordToGuess = word.ToUpper();
        _guessedLetters = new string('_', _wordToGuess.Length).ToCharArray();
    }

    public override string ToString()
    {
        return new string(_guessedLetters);
    }

    public bool CompletelyGuessed()
    {
        return false;
    }

    public bool CheckGuess(char letter)
    {
        return false;
    }

    public bool CheckCompleteGuess(string word)
    {
        return false;
    }
}