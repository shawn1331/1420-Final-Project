// Shawn Miner Fall 2024 1420 Final Project Hangman
using Hangman.Logic;

Game getWordFromGame = new();
string word = getWordFromGame.SelectWordToGuess();
Player player1 = new HumanPlayer("Shawn", GetUserGuess, GetUsersCompleteGuess);
Player player2 = new AIPlayer(GetUserGuess, GetUsersCompleteGuess);
Game game = new(player1, player2, word);

bool playAgain = true;
Console.Clear();

while (playAgain)
{
    game.PlayGame();

    Console.WriteLine("Would you like to play again? y/n");
    char loopAgain = Console.ReadKey().KeyChar;

    if (loopAgain == 'y')
        game.ResetGameState(word);


    else
        playAgain = false;
}

Console.Clear();
Console.WriteLine("Thank you for playing!");












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
