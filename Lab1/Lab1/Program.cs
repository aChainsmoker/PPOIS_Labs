namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        Wedding wedding = JsonStateManager.LoadState<Wedding>("weddingState.json");
        
        if(wedding == null)
            wedding = new Wedding(new ChoosingWeddingPhaseState());
        else
            wedding.CurrentWeddingPhase = IOSystem.GetTheWeddingPhaseFromString(wedding.CurrentWeddingPhaseString);

        while (!wedding.IsConcluded)
        {
            wedding.ChangeState();
        }
    }
}