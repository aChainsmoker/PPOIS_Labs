namespace Lab1;

public class PhotoSessionState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.DeclarePhotoSession();
        Console.ReadKey();
        Console.Clear();
        wedding.WeddingPhase = new BanquetState();
    }
}