namespace Hangman.Logic;
public class HumanPlayer :  Player
{
    public HumanPlayer(string name, Game.GetGuessDelegate getGuess) : base(name, getGuess)
    {
        
    }

    public override char MakeGuess()
    {
        return GetGuess();
    }
}