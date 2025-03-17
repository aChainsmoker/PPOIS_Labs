namespace Lab1;

public class ChoosingWeddingPhaseState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.ChooseWeddingPhase(out int indexOfWeddingPhase);
        IOSystem.Clear();
        PhaseRerouter.AssignThePhase(wedding, indexOfWeddingPhase);
    }
}