namespace Lab1;

public class ChoosingWeddingAttributesState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingMenuState();
        IOSystem.PrintBudget(wedding.SharedBudget);
        SuitStore suitStore = new SuitStore();
        RingStore ringStore = new RingStore();
        IOSystem.ChooseWeddingAttributes(suitStore, ringStore,  out int indexOfFianceeDress, out int indexOfGroomDress, out int indexOfRing);
        if (ResultSummarizer.CalculateDeadEnd(wedding, suitStore.WomenSuits.Select(item => item.Price).ToList())) return;
        suitStore.AssignTheSuitToTheFiancee(wedding, indexOfFianceeDress);
        if (ResultSummarizer.CalculateDeadEnd(wedding, suitStore.MenSuits.Select(item => item.Price).ToList())) return;
        suitStore.AssignTheSuitToTheGroom(wedding, indexOfGroomDress);
        if (ResultSummarizer.CalculateDeadEnd(wedding, ringStore.Rings.Select(item => item.Price).ToList())) return;
        ringStore.AssignTheRings(wedding, indexOfRing);
        Console.Clear();
    }
}