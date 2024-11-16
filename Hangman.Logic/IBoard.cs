using Hangman.Logic;

public interface IBoard
{
    void PrintHangedMan();
    void PrintWord(Word word);
    bool HasGuesses();
    void AddToMissedGuesses(char guess);
    void ShowPastGuesses();
    void PrintPoints(Player player);

}