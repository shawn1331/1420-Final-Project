public interface IPlayer
{
   abstract char MakeGuess();
   abstract string MakeCompleteGuess();
   int UpdateScore(int points);
}