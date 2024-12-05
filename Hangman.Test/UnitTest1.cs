using FluentAssertions;
using Hangman.Logic;
namespace Hangman.Test;

public class UnitTest1
{
    [Fact]
    public void TestAIMakeGuessReturnsCapitals() //REQ#1.1.1
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
    public void TestAIMakeGuessNotRedrawingLettersAlreadyDrawn() //REQ#1.1.2 now fixed and passes
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
        char aiGuess;
        AIPlayer aI = new(GetUserGuess, GetUsersCompleteGuess);
        HumanPlayer player = new("Shawn", GetUserGuess, GetUsersCompleteGuess);
        Game game = new(player, aI, "hello");
        for (int i = 0; i < 20; i++)
        {
            aiGuess = aI.MakeGuess();
        }
        aiGuess = aI.MakeGuess();
        aI.drawnLetters.Should().HaveElementAt(aI.drawnLetters.Count - 1, aiGuess); //  char is added to the list before the method returns so the list should contain the last guess at Count - 1
    }

    [Fact]
    public void TestHasGuesses()//REQ#1.2.1
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.PlayerHasGuesses().Should().Be(true);
    }

    [Fact]
    public void TestHasGuessesReducesAfterMissingGuessAndPlayerAddToMissedGuesses()//REQ#1.2.2 now fixed and passes
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.Word = new("test");
        char playerGuess = 'H';
        player.Word.CheckGuess(playerGuess);
        player.AddToMissedGuesses(playerGuess);
        player.IncorrectGuesses.Should().Contain(playerGuess);
        player.PlayerHasGuesses().Should().Be(true);
        player.MaxMissedGuesses.Should().Be(5);
    }

    [Fact]
    public void TestBoardMaxGuesses()//REQ#1.3.1
    {
        Game game = new("hello");
        game.Board.MaxMissedGuesses.Should().Be(6);
    }

    [Fact]
    public void TestBoardMaxGuessesReducingAfterGuess()//REQ#1.3.2
    {
        Game game = new("hello");
        char guess = 'R';

        if (!game.Word.CheckGuess(guess))
        {
            game.Board.AddToBoardMissedGuesses(guess);
        }
        game.Board.MaxMissedGuesses.Should().Be(5);
    }

    [Fact]
    public void TestCheckGuessWithWrongLetter()//REQ#1.4.2
    {
        Game game = new("hello");
        char guess = 'A';
        game.Word.CheckGuess(guess).Should().Be(false);
    }


    [Fact]
    public void TestCheckGuessWithCorrectLetter()//REQ#1.4.1
    {
        Game game = new("hello");
        char guess = 'E';
        game.Word.CheckGuess(guess).Should().Be(true);
    }

    [Fact]
    public void TestCheckCompleteGuessShouldBeTrue()//REQ#1.5.1
    {
        Word word = new("hello");
        string guess = "hello";
        word.CheckCompleteGuess(guess).Should().Be(true);
    }

    [Fact]
    public void TestCheckCompleteGuessWithIncorrectLengthShouldThrowException()//REQ#1.5.2
    {
        Word word = new("hello");
        string guess = "asdfjl";
        Action act = () => word.CheckCompleteGuess(guess);
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void TestCheckCompleteGuessShouldBeFalse()//REQ#1.5.2
    {
        Word word = new("hello");
        string guess = "asdfj";
        word.CheckCompleteGuess(guess).Should().Be(false);
    }

    [Fact]
    public void TestCompletelyGuessedShouldBeTrue()//REQ#1.6.1
    {
        Word word = new("hello");
        string guess = "hello";
        word.CheckCompleteGuess(guess);
        word.CompletelyGuessed().Should().Be(true);
    }

    [Fact]
    public void TestCompletelyGuessedShouldBeFalse()//REQ#1.6.2
    {
        Word word = new("hello");
        string guess = "asdfg";
        word.CheckCompleteGuess(guess);
        word.CompletelyGuessed().Should().Be(false);
    }

    [Fact]
    public void TestBoardAddToMissedGuesses()
    {
        Board board = new();
        Word word = new("hello");
        char guess = 'A';
        if (!word.CheckGuess(guess))
        {
            board.AddToBoardMissedGuesses(guess);
        }
        board.IncorrectGuesses.Should().BeEquivalentTo(new List<char> { 'A' });

    }

    [Fact]
    public void TestPlayerScore()//REQ#1.7.1
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.Word = new("test");
        char playerGuess = 'E';
        player.Word.CheckGuess(playerGuess);
        player.UpdateScore(player.Word.NumberOfGuessedLetters * 5);
        player.Score.Should().Be(5);

    }

    [Fact]
    public void TestPlayerScoreWithMultipleLetters()//REQ#1.7.2
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.Word = new("test");
        char playerGuess = 'T';
        player.Word.CheckGuess(playerGuess);
        player.UpdateScore(player.Word.NumberOfGuessedLetters * 5);
        player.Score.Should().Be(10);

    }

    [Fact]
    public void TestScoreWithCompleteGuessWithCorrectGuess()//REQ#1.8.1
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.Word = new("test");
        string playerGuess = "TEST";
        int numberOfLetters = player.Word.RemainingLetterCount;
        player.Word.CheckCompleteGuess(playerGuess);
        if (player.Word.CompletelyGuessed())
            player.UpdateScore(numberOfLetters * 10);

        player.Score.Should().Be(40);
    }

    [Fact]
    public void TestScorewithCompleteGuessWithWrongGuess()//REQ#1.8.2
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
        Player player = new HumanPlayer("test", GetUserGuess, GetUsersCompleteGuess);
        player.Word = new("test");
        string playerGuess = "BOMB";
        player.Word.CheckCompleteGuess(playerGuess);

        if (player.Word.CompletelyGuessed())
            player.UpdateScore(player.Word.RemainingLetterCount * 10);

        player.Score.Should().Be(0);

    }
}
