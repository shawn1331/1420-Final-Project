namespace Hangman.Logic;
public class AIPlayer : Player
{

    public AIPlayer(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess) : base(name, getGuess, getCompleteGuess)
    {

    }

    public override char MakeGuess()
    {
        Random rand = new();
        return (char)('A' + rand.Next(0,26));
    }

    public override string MakeCompleteGuess()
    {
        return "";
    }
}