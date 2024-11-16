namespace Hangman.Logic;
public class AIPlayer : Player
{

    public AIPlayer(Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, string name = "AI") : base(name, getGuess, getCompleteGuess)
    {

    }

    public override char MakeGuess()
    {
        return (char)('A' + Game._random.Next(0,26));
    }

    public override string MakeCompleteGuess()
    {
        return "";
    }
}