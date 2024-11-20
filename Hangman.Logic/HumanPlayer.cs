namespace Hangman.Logic;
public class HumanPlayer : Player  //inheritence
{
    public HumanPlayer(string name, Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, string wordToGuess) : base(name, getGuess, getCompleteGuess, wordToGuess)  // chaining constructor from base class
    {
        
    }

    public override char MakeGuess()  // polymorphism/ overridden method
    {
        return GetGuess();
    }

    public override string MakeCompleteGuess()  // polymorphism/ overridden method
    {
        return GetCompleteGuess();
    }
}