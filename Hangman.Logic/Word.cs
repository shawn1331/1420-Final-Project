public class Word
{
    private string _wordToGuess;
    private char[] _revealedLetters;
    
    public Word(string word)
    {
        _wordToGuess = word.ToUpper();
        _revealedLetters = new string('_', _wordToGuess.Length).ToCharArray();
    }

    public override string ToString()
    {
        return new string(_revealedLetters);
    }

    public bool CompletelyGuessed()
    {
        return false;
    }
}