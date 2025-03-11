namespace Lab1;

public class CreatingNewlywedState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.ChooseNameForNewlyweds(out string husbandName, out string wifeName);
        wedding.Groom = new Groom(husbandName);
        wedding.Fiancee = new Fiancee(wifeName);
        wedding.SharedBudget = (int)(wedding.Groom.Budget + wedding.Fiancee.Budget);
        IOSystem.Clear();
        wedding.WeddingPhase = new ChoosingWeddingPlaceState();
    }
}