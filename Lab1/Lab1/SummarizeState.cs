namespace Lab1;

public class SummarizeState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.IsConcluded = true;
        int amountOfPoints = ResultSummarizer.Summarize(wedding);
        IOSystem.DisplaySummarazation(amountOfPoints);

        try
        {
            if(amountOfPoints > Convert.ToInt32(JsonStateManager.LoadState<string>("WeddingRecord.json")))
                JsonStateManager.SaveState(amountOfPoints.ToString(), "WeddingRecord.json");
        }
        catch (FormatException)
        {
            throw new FormatException("The record data is in invalid format.");
        }
        
        Console.ReadLine();
        JsonStateManager.DeleteState("WeddingState.json");
    }
}