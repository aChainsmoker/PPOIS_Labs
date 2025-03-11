namespace Lab1;

public class GuestInvitationState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.InviteGuests(out string[] names);
        wedding.Fiancee.InviteGuests(names, wedding);
        IOSystem.Clear();
        wedding.Ceremony = new Ceremony(wedding.Groom, wedding.Fiancee, wedding.Guests);
        wedding.WeddingPhase = new CeremonyState();
    }
}