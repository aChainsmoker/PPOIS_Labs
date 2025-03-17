namespace Lab1;

public class ChoosingWeddingMenuState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        JsonStateManager.SaveState(wedding, "WeddingState.json");
        IOSystem.PrintBudget(wedding.SharedBudget);
        WeddingMenu weddingMenu = new WeddingMenu();
        IOSystem.ChooseWeddingMenu(weddingMenu, out int[] indexesOfWeddingMenu);
        if (wedding.Banquet.Dishes.Count != 0)
            weddingMenu.ReturnMoney(wedding);
        weddingMenu.AssignTheDishes(wedding, indexesOfWeddingMenu);
        IOSystem.Clear();
        wedding.CurrentWeddingPhase = new ChoosingWeddingPhaseState();;
    }
}