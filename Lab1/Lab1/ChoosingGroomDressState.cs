namespace Lab1;

public class ChoosingGroomDressState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        SuitStore suitStore = new SuitStore();
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingDressForGroom(suitStore, out int indexOfGroomDress);
        if (wedding.Groom.Suit != null)
            suitStore.ReturnMoney(wedding, wedding.Groom);
        suitStore.AssignTheSuitToTheGroom(wedding, indexOfGroomDress);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}