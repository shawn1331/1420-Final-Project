using FluentAssertions;
using Hangman.Logic;
namespace Hangman.Test;

public class UnitTest1
{
    [Fact]
    public void TestAIMakeGuessReturnsCapitals()
    {
        static char GetUserGuess()
        {
            Console.WriteLine("Please enter the letter you would like to guess: ");
            char userGuess = Console.ReadKey().KeyChar;

            if (char.IsAsciiLetter(userGuess))
                return userGuess;

            else
            {
                Console.WriteLine("That is an invalid entry. Please try again.");
                return GetUserGuess();
            }
        }

        static string GetUsersCompleteGuess()
        {
            bool flagNonLetter = false;
            Console.Write("What is your guess: ");
            string completeGuess = Console.ReadLine().ToUpper();
            foreach (char letter in completeGuess)
            {
                if (!char.IsAsciiLetter(letter))
                {
                    flagNonLetter = true;
                }
                if (flagNonLetter)
                {
                    Console.WriteLine("That guess contains invalid characters, try again.");
                    return GetUsersCompleteGuess();
                }
            }
            return completeGuess;
        }
        AIPlayer aI = new("AI", GetUserGuess, GetUsersCompleteGuess);
        HumanPlayer player = new("Shawn", GetUserGuess, GetUsersCompleteGuess);
        Game game = new(player, aI, "hello", 6);
        char aiGuess = aI.MakeGuess();
        aiGuess.Should().BeOneOf('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');
    }

    [Fact]
    public void TestHasGuesses()
    {
        Board board = new(6);
        board.HasGuesses().Should().Be(true);
    }

    [Fact]
    public void TestPlayerMakeGuess()
    {

    }

    [Fact]
    public void TestCompletelyGuessed()
    {

    }

    [Fact]
    public void TestPrintBoard()
    {

    }

    [Fact]
    public void TestPrintWord()
    {

    }

    [Fact]
    public void Test()
    {

    }
}
