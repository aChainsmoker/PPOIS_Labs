namespace Lab1;

public class ChoosingWeddingMenuState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new CeremonyState();
    }
}