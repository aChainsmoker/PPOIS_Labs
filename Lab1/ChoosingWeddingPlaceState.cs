namespace Lab1;

public class ChoosingWeddingPlaceState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingAttributesState();
        IOSystem.PrintBudget(wedding.SharedBudget);
        WeddingMap weddingMap = new WeddingMap();
        if (ResultSummarizer.CalculateDeadEnd(wedding, weddingMap.WeddingPlaces.Select(item => item.Price).ToList())) return;
        IOSystem.ChooseWeddingPlace(weddingMap, out int indexOfPlace);
        weddingMap.AssignThePlace(wedding, indexOfPlace);
        Console.Clear();
    }
}