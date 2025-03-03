namespace Lab1;

public class CeremonyState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new PhotosessionState();
    }
}