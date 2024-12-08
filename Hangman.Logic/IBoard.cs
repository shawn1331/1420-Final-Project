namespace Hangman.Logic;

public interface IBoard // REQ#2.2.1 
{
    string GetHangedMan();
    void PrintWord(Word word);
    void PrintPoints(Player player);

}