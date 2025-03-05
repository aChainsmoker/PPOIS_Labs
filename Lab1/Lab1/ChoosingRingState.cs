namespace Lab1;

public class ChoosingRingState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        RingStore ringStore = new RingStore();
        
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingRing(ringStore,  out int indexOfRing);
        if (ResultSummarizer.CalculateDeadEnd(wedding, ringStore.Rings.Select(item => item.Price).ToList())) return;
        ringStore.AssignTheRings(wedding, indexOfRing);
        Console.Clear();
        wedding.WeddingPhase = new ChoosingWeddingMenuState();
    }
}