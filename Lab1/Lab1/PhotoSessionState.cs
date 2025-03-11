namespace Lab1;

public class PhotoSessionState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.DeclarePhotoSession();
        Console.ReadLine();
        IOSystem.Clear();
        wedding.WeddingPhase = new BanquetState();
    }
}