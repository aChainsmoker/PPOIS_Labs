namespace Lab1;

public class SummarizeState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.IsConcluded = true;
        int amountOfPoints = ResultSummarizer.Summarize(wedding);
        IOSystem.Summarize(amountOfPoints);
        Console.ReadKey();
    }
}