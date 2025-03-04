namespace Lab1;

public class BanquetState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new SummarizeState();
        IOSystem.DeclareBanquet();
        Console.ReadKey();
        Console.Clear();
    }
}