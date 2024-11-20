namespace Hangman.Logic;

public interface IBoard // 1st use of an interface 
{
    void PrintHangedMan();
    void PrintWord(Word word);
    void PrintPoints(Player player);

}