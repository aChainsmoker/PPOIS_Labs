namespace Lab1;

public class ChoosingGroomDressState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        SuitStore suitStore = new SuitStore();

        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingDressForGroom(suitStore, out int indexOfGroomDress);
        if (ResultSummarizer.CalculateDeadEnd(wedding, suitStore.MenSuits.Select(item => item.Price).ToList())) return;
        suitStore.AssignTheSuitToTheGroom(wedding, indexOfGroomDress);
        Console.Clear();
        wedding.WeddingPhase = new ChoosingRingState();
    }
}