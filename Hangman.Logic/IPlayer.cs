namespace Hangman.Logic;
public interface IPlayer // REQ#2.2.1
{
   public List<char> IncorrectGuesses { get; }
   public int Score { get; }
   // public Board Board { get; }
   public int MaxMissedGuesses { get; }
   public abstract char MakeGuess();
   public abstract string MakeCompleteGuess();
   public int UpdateScore(int points);
}