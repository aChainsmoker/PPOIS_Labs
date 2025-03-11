using System.Diagnostics;

namespace Lab1;

public class CeremonyState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.Ceremony.DeclareHusbandAndWife(wedding.Groom, wedding.Fiancee);
        IOSystem.DeclareMarriage(wedding.Groom, wedding.Fiancee);
        Console.ReadLine();
        IOSystem.Clear();
        wedding.WeddingPhase = new PhotoSessionState();
    }
}