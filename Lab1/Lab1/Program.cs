namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        //Console.SetIn(new StringReader("A\nB\n1\n1\n1\n1\n"));
        Wedding wedding = JsonStateManager.LoadState<Wedding>("weddingState.json");
        
        if(wedding == null)
            wedding = new Wedding(new CreatingNewlywedState());
        else
            wedding.WeddingPhase = IOSystem.GetTheWeddingPhaseFromString(wedding.WeddingPhaseString);

        while (!wedding.IsConcluded)
        {
            wedding.ChangeState();
        }
    }
}