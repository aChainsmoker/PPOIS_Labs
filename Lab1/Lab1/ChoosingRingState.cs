namespace Lab1;

public class ChoosingRingState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        RingStore ringStore = new RingStore();
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingRing(ringStore,  out int indexOfRing);
        ringStore.AssignTheRings(wedding, indexOfRing);
        IOSystem.Clear();
        wedding.WeddingPhase = new ChoosingWeddingMenuState();
    }
}