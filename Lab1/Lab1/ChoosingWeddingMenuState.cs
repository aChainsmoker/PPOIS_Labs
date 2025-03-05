namespace Lab1;

public class ChoosingWeddingMenuState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.PrintBudget(wedding.SharedBudget);
        WeddingMenu weddingMenu = new WeddingMenu();
        IOSystem.ChooseWeddingMenu(weddingMenu, out int[] indexesOfWeddingMenu);
        if (ResultSummarizer.CalculateDeadEnd(wedding, weddingMenu.Dishes.Select(item => item.Price*5).ToList())) return;
        weddingMenu.AssignTheDishes(wedding, indexesOfWeddingMenu);
        Console.Clear();
        wedding.WeddingPhase = new GuestInvitationState();
    }
}