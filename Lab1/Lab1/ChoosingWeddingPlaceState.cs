namespace Lab1;

public class ChoosingWeddingPlaceState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.PrintBudget(wedding.SharedBudget);
        WeddingMap weddingMap = new WeddingMap();
        IOSystem.ChooseWeddingPlace(weddingMap, out int indexOfPlace);
        if (wedding.WeddingPlace != null)
            weddingMap.ReturnMoney(wedding);
        weddingMap.AssignThePlace(wedding, indexOfPlace);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}