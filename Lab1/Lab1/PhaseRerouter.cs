namespace Lab1;

public static class PhaseRerouter
{
    private static  List<WeddingPhase> _weddingPhases = new List<WeddingPhase>(){new CreatingNewlywedState(), new ChoosingWeddingPlaceState(), new ChoosingFianceeDressState(),
        new ChoosingGroomDressState(), new ChoosingRingState(), new ChoosingWeddingMenuState(), new GuestInvitationState(), new CeremonyState(), new PhotoSessionState(), new BanquetState(), new SummarizeState()};
    
    public static List<WeddingPhase> WeddingPhases { get => _weddingPhases; set => _weddingPhases = value; }

    public static void AssignThePhase(Wedding wedding, int index)
    {
        wedding.CurrentWeddingPhase = _weddingPhases[index];


        switch (wedding.CurrentWeddingPhase)
        {
            case ChoosingRingState:
            case ChoosingFianceeDressState:
            case ChoosingGroomDressState:
                if (!CheckIfTheWeddingHasGroomAndFiancee(wedding))
                {
                    IOSystem.DisplayBuyingAttributesRequirements();
                    wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
                }
                break;
            case PhotoSessionState:
                if (!CheckIfWeddingCorrespondToBasicRequirements(wedding))
                {
                    IOSystem.DisplayPhotoSessionRequirements();
                    wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
                }

                break;
            case CeremonyState:
                if (!CheckIfWeddingCorrespondToAdditionalRequirements(wedding))
                {
                    IOSystem.DisplayCeremonyRequirements();
                wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
                }
                break;
            case BanquetState:
                if (!CheckIfWeddingCorrespondToAdditionalRequirements(wedding))
                {
                    IOSystem.DisplayBanquetRequirements();
                wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
                }
                break;
            case SummarizeState:
                if (!CheckIfWeddingCorrespondToAdditionalRequirements(wedding))
                {
                    IOSystem.DisplaySummarizationRequirements();
                wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();
                }
                break;
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

    private static bool CheckIfTheWeddingHasGroomAndFiancee(Wedding wedding)
    {
        if(wedding.Groom == null || wedding.Fiancee == null)
            return false;
        return true;
    }
}