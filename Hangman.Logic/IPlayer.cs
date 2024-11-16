namespace Hangman.Logic;
public interface IPlayer // 2nd use of an interface
{
   abstract char MakeGuess();
   abstract string MakeCompleteGuess();
   int UpdateScore(int points);
}