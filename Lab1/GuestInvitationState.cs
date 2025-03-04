namespace Lab1;

public class GuestInvitationState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new CeremonyState();
        IOSystem.InviteGuests(out string[] names);
        wedding.Wife.InviteGuests(names, wedding);
        Console.Clear();
        
        wedding.Ceremony = new Ceremony(wedding.Husband, wedding.Wife, wedding.Guests);
    }
}