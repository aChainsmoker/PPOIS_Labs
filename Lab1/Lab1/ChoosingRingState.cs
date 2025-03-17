namespace Lab1;

public class ChoosingRingState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        RingStore ringStore = new RingStore();
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingRing(ringStore,  out int indexOfRing);
        if(wedding.Groom.Ring != null)
            ringStore.ReturnMoney(wedding);
        ringStore.AssignTheRings(wedding, indexOfRing);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}