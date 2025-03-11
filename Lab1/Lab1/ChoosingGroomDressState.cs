namespace Lab1;

public class ChoosingGroomDressState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        SuitStore suitStore = new SuitStore();
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingDressForGroom(suitStore, out int indexOfGroomDress);
        suitStore.AssignTheSuitToTheGroom(wedding, indexOfGroomDress);
        IOSystem.Clear();
        wedding.WeddingPhase = new ChoosingRingState();
    }
}