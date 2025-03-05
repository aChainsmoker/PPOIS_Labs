namespace Lab1;

public class LostGameState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.IsConcluded = true;
        IOSystem.PrintLoserScreen();
    }
}