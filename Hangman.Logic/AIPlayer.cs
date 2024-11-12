namespace Hangman.Logic;
public class AIPlayer : Player
{

    public AIPlayer(string name, Game.GetGuessDelegate getGuess) : base(name, getGuess)
    {

    }

    public override char MakeGuess()
    {
        return default;
    }
}