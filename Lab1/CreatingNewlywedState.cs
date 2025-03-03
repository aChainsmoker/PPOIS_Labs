namespace Lab1;

public class CreatingNewlywedState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingPlaceState();
    }
}