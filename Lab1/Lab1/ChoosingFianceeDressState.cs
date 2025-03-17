namespace Lab1;

public class ChoosingFianceeDressState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        SuitStore suitStore = new SuitStore();
        IOSystem.PrintBudget(wedding.SharedBudget);
        IOSystem.ChooseWeddingDressForFiancee(suitStore,  out int indexOfFianceeDress);
        if (wedding.Fiancee.Suit != null)
            suitStore.ReturnMoney(wedding, wedding.Fiancee);
        suitStore.AssignTheSuitToTheFiancee(wedding, indexOfFianceeDress);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}