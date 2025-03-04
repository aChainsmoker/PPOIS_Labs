namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        //Console.SetIn(new StringReader("A\nB\n1\n1\n1\n1\n"));
        Wedding wedding = new Wedding(new CreatingNewlywedState());

        while (!wedding.IsConcluded)
        {
            wedding.ChangeState();
        }
    }
}