namespace Hangman.Logic;
public class AIPlayer : Player  // inheritence 
{
    public List<char> drawnLetters { get; private set; }

    public AIPlayer(Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, string name = "AI") : base(name, getGuess, getCompleteGuess)  // chaining constructor from base class also optional argument
    {
        drawnLetters = new();
    }

    public override char MakeGuess()  // polymorphism/ overridden method
    {
        char guess = (char)('A' + Game._random.Next(0, 26));
        while (drawnLetters.Contains(guess))
        {
            guess = (char)('A' + Game._random.Next(0, 26));
        }
        drawnLetters.Add(guess);
        return guess;
    }

    public override string MakeCompleteGuess()  // polymorphism/ overridden method
    {
        return "";
    }
}