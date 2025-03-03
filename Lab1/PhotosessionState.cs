namespace Lab1;

public class PhotosessionState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingAttributesState();
    }
}