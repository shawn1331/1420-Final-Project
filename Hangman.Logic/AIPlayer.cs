namespace Hangman.Logic;
public class AIPlayer : Player  // inheritence 
{
    private List<char> drawnLetters { get; set; }

    public AIPlayer(Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, string name = "AI") : base(name, getGuess, getCompleteGuess)  // chaining constructor from base class also optional argument
    {
        drawnLetters = new();
    }

    public override char MakeGuess()  // polymorphism/ overridden method
    {
        return (char)('A' + Game._random.Next(0, 26));
    }

    public override string MakeCompleteGuess()  // polymorphism/ overridden method
    {
        return "";
    }
}