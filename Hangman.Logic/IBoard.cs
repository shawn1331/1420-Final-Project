public interface IBoard
{
    void PrintHangedMan();
    void PrintWord();
    bool HasGuesses();
    void AddToGuesses(char guess);
    void ShowPastGuesses();

}