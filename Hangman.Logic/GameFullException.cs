namespace Hangman.Logic;

[Serializable]
internal class GameFullException : Exception // creation of a new exception type to throw exceptions when the game is full
{
    public GameFullException()
    {
    }

    public GameFullException(string? message) : base(message)
    {
    }

    public GameFullException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}