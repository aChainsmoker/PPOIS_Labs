namespace Lab1;

public class ChoosingWeddingAttributesState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingMenuState();
    }
}