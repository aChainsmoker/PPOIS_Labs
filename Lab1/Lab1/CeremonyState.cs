namespace Lab1;

public class CeremonyState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.Ceremony.DeclareHusbandAndWife(wedding.Groom, wedding.Fiancee);
        IOSystem.DeclareMarriage(wedding.Groom, wedding.Fiancee);
        Console.ReadKey();
        Console.Clear();
        wedding.WeddingPhase = new PhotoSessionState();
    }
}