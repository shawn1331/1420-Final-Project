namespace Hangman.Logic;
public class HumanPlayer : Player, IPlayer  // REQ#2.1.2 REQ#2.2.1
{
    public HumanPlayer(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess) : base(name, getGuess, getCompleteGuess)  // chaining constructor from base class
    {
        
    }

    public override char MakeGuess()  // polymorphism/ overridden method
    {
        return GetGuess();   // using the delegate variables 
    }

    public override string MakeCompleteGuess()  // polymorphism/ overridden method
    {
        return GetCompleteGuess();  // using the delegate variables
    }
}