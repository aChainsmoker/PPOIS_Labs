namespace Lab1;

public class GuestInvitationState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.InviteGuests(out string[] names);
        Newlywed.InviteGuests(names, wedding);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}