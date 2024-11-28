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
        AIPlayer aI = new(GetUserGuess, GetUsersCompleteGuess);
        HumanPlayer player = new("Shawn", GetUserGuess, GetUsersCompleteGuess);
        Game game = new(player, aI, "hello");
        char aiGuess = aI.MakeGuess();
        aiGuess.Should().BeOneOf('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    }

    [Fact]
    public void TestHasGuesses()
    {
        Board board = new();
        board.BoardHasGuesses().Should().Be(true);
    }

    [Fact]
    public void TestMaxGuessesReducingAfterGuess()
    {
        Game game = new();
        Word word = new("hello");
        Board board = new();
        char guess = 'R';
    
        if (!word.CheckGuess(guess))
        {
            board.AddToBoardMissedGuesses(guess);
        }
        board.MaxMissedGuesses.Should().Be(5);
    }

    [Fact]
    public void TestCheckGuessWithWrongLetter()
    {
        Word word = new("hello");
        char guess = 'A';
        word.CheckGuess(guess).Should().Be(false);
    }
    

    [Fact]
    public void TestCheckGuessWithCorrectLetter()
    {
        Word word = new("hello");
        char guess = 'E';
        word.CheckGuess(guess).Should().Be(true);
    }

    [Fact]
    public void TestCheckCompleteGuessShouldBeTrue()
    {
        Word word = new("hello");
        string guess = "hello";
        word.CheckCompleteGuess(guess).Should().Be(true);
    }

    [Fact]
    public void TestCheckCompleteGuessShouldBeFalse()
    {
        Word word = new("hello");
        string guess = "asdfj";
        word.CheckCompleteGuess(guess).Should().Be(false);
    }

    [Fact]
    public void TestCompletelyGuessedShouldBeTrue()
    {
        Word word = new("hello");
        string guess = "hello";
        word.CheckCompleteGuess(guess);
        word.CompletelyGuessed().Should().Be(true);
    }

    [Fact]
    public void TestCompletelyGuessedShouldBeFalse()
    {
        Word word = new("hello");
        string guess = "asdfg";
        word.CheckCompleteGuess(guess);
        word.CompletelyGuessed().Should().Be(false);
    }

    [Fact]
    public void TestPrintBoard()
    {

    }

    // [Fact]
    // public void TestPrintWord()
    // {
    //     Word word = new("hello");
    //     Board board = new(6);
    //     word._guessedLetters.Should().BeEquivalentTo<char>(new char []{'_','_','_','_','_'});
    // }

    [Fact]
    public void TestAddToGuesses()
    {
        Board board = new();
        Word word = new("hello");
        char guess = 'L';
        word.CheckGuess(guess);
        board.AddToBoardMissedGuesses(guess);
        board.IncorrectGuesses.Should().BeEquivalentTo(new List<char> {'L'});
        
    }
}
