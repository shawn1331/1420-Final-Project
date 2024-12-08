namespace Hangman.Logic;
public class AIPlayer : Player, IPlayer  // REQ#2.1.2 REQ#2.2.1
{
    public List<char> drawnLetters { get; private set; }

    public AIPlayer(Game.GetGuessDelegate getGuess, Game.GetCompleteGuessDelegate getCompleteGuess, Game.GetInputDelegate getInput, string name = "AI") : base(name, getGuess, getCompleteGuess, getInput)  // chaining constructor from base class also optional argument
    {
        drawnLetters = new();
    }

    public override char MakeGuess()  // REQ#1.1.3
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

    public override char GetUserInput()
    {
        return ' ';
    }
}