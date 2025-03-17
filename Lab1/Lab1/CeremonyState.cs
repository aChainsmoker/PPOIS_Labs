using System.Diagnostics;

namespace Lab1;

public class CeremonyState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.Ceremony.DeclareHusbandAndWife(wedding.Groom, wedding.Fiancee);
        if(wedding.Ceremony.WasHeld == true)
            IOSystem.ShowAlreadyMarriedStatus();
        else
        {
            IOSystem.DeclareMarriage(wedding.Groom, wedding.Fiancee);
            wedding.Ceremony.WasHeld = true;
        }

        Console.ReadLine();
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}