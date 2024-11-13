// Shawn Miner Fall 2024 1420 Final Project Hangman













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
