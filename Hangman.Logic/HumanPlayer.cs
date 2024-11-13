namespace Hangman.Logic;
public class HumanPlayer :  Player
{
    public HumanPlayer(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess) : base(name, getGuess, getCompleteGuess)
    {
        
    }

    public override char MakeGuess()
    {
        return GetGuess();
    }

    public override string MakeCompleteGuess()
    {
        return GetCompleteGuess();
    }
}