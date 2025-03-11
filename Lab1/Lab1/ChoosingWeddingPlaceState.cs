namespace Lab1;

public class ChoosingWeddingPlaceState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.PrintBudget(wedding.SharedBudget);
        WeddingMap weddingMap = new WeddingMap();
        IOSystem.ChooseWeddingPlace(weddingMap, out int indexOfPlace);
        weddingMap.AssignThePlace(wedding, indexOfPlace);
        IOSystem.Clear();
        wedding.WeddingPhase = new ChoosingFianceeDressState();
    }
}