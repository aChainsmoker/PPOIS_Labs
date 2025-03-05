namespace Lab1;

public class ChoosingFianceeDressState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        SuitStore suitStore = new SuitStore();
        
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingDressForFiancee(suitStore,  out int indexOfFianceeDress);
        if (ResultSummarizer.CalculateDeadEnd(wedding, suitStore.WomenSuits.Select(item => item.Price).ToList())) return;
        suitStore.AssignTheSuitToTheFiancee(wedding, indexOfFianceeDress);
        Console.Clear();
        wedding.WeddingPhase = new ChoosingGroomDressState();
    }
}