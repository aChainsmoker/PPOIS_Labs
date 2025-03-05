namespace Lab1;

public class BanquetState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.WeddingPhase = new SummarizeState();
        IOSystem.DeclareBanquet();
        Console.ReadKey();
        Console.Clear();
    }
}