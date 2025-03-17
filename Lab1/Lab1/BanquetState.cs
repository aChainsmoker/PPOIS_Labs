namespace Lab1;

public class BanquetState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
        if(wedding.Banquet.WasHeld == true)
            IOSystem.ShowAlreadyHeldBanquetStatus();
        else
        {
            IOSystem.DeclareBanquet();
            wedding.Banquet.WasHeld = true;
        }

        Console.ReadLine();
        IOSystem.Clear();
    }
}