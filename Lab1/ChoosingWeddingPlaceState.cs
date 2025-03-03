namespace Lab1;

public class ChoosingWeddingPlaceState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingAttributesState();
    }
}