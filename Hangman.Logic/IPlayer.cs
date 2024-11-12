public interface IPlayer
{
   void AddToGuesses(char guess);
   void ShowPastGuesses();
   abstract char MakeGuess();
}