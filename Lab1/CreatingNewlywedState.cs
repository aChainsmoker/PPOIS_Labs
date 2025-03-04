namespace Lab1;

public class CreatingNewlywedState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new ChoosingWeddingPlaceState();
        IOSystem.ChooseNameForNewlyweds(out string husbandName, out string wifeName);
        wedding.Husband = new Husband(husbandName);
        wedding.Wife = new Wife(wifeName);
        wedding.SharedBudget = (int)(wedding.Husband.Budget + wedding.Wife.Budget);
        Console.Clear();
    }
}