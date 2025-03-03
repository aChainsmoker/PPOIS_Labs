namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        Wedding wedding = new Wedding(new CreatingNewlywedState());

        while (!wedding.IsConcluded)
        {
            wedding.ChangeState();
        }
    }
}