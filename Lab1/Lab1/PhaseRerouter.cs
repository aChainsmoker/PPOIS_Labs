namespace Lab1;

public static class PhaseRerouter
{
    private static  List<WeddingPhase> _weddingPhases = new List<WeddingPhase>(){new CreatingNewlywedState(), new ChoosingWeddingPlaceState(), new ChoosingFianceeDressState(),
        new ChoosingGroomDressState(), new ChoosingRingState(), new ChoosingWeddingMenuState(), new GuestInvitationState(), new CeremonyState(), new PhotoSessionState(), new BanquetState(), new SummarizeState()};
    
    public static List<WeddingPhase> WeddingPhases { get => _weddingPhases; set => _weddingPhases = value; }

    public static void AssignThePhase(Wedding wedding, int index)
    {
        wedding.CurrentWeddingPhase = _weddingPhases[index];
        
        if (!CheckIfWeddingCorrespondToBasicRequirements(wedding))
        {
            switch (wedding.CurrentWeddingPhase)
            {
                case CeremonyState ceremonyState:
                    IOSystem.DisplayCeremonyRequirements();
                    break;
                case PhotoSessionState photoSessionState:
                    IOSystem.DisplayPhotoSessionRequirements();
                    break;
                case BanquetState banquetState:
                    IOSystem.DisplayBanquetRequirements();
                    break;
                case SummarizeState summarizeState:
                    IOSystem.DisplaySummarizationRequirements();
                    break;
                default:
                    return;
            }
            wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
        }
        else if (!CheckIfWeddingCorrespondToAdditionalRequirements(wedding))
        {
            switch (wedding.CurrentWeddingPhase)
            {
                case CeremonyState ceremonyState:
                    IOSystem.DisplayCeremonyRequirements();
                    break;
                case BanquetState banquetState:
                    IOSystem.DisplayBanquetRequirements();
                    break;
                case SummarizeState summarizeState:
                    IOSystem.DisplaySummarizationRequirements();
                    break;
                default:
                    return;
            }
            wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
        }
    }

    private static bool CheckIfWeddingCorrespondToBasicRequirements(Wedding wedding)
    {
        if (wedding.Groom == null || wedding.Fiancee == null || wedding.Groom.Ring == null ||
            wedding.Groom.Suit == null || wedding.Fiancee.Suit == null || wedding.WeddingPlace == null)
            return false;
        return true;
    }

    private static bool CheckIfWeddingCorrespondToAdditionalRequirements(Wedding wedding)
    {
        if(wedding.Guests.Count == 0 || wedding.Banquet.Dishes.Count == 0)
            return false;
        return true;
    }
}