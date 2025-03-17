namespace Lab1;

public class CreatingNewlywedState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.ChooseNameForNewlyweds(out string groomName, out string fienceeName);
        if (wedding.Groom == null)
        {
            wedding.Groom = new Groom(groomName);
            wedding.Fiancee = new Fiancee(fienceeName);
        }
        else
        {
            wedding.Groom.Name = groomName;
            wedding.Fiancee.Name = fienceeName;
        }
        wedding.SharedBudget = (int)(wedding.Groom.Budget + wedding.Fiancee.Budget);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}