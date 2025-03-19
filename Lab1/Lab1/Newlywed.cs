namespace Lab1;

public class Newlywed
{
    private uint _budget;
    private string _name;

    private Suit _suit;
    private bool _isMarried;
    private Ring _ring;
    
    public uint Budget{ get => _budget; set => _budget = value; }
    public string Name { get => _name; set => _name = value; }
    public Suit Suit { get => _suit; set => _suit = value; }
    public bool IsMarried { get => _isMarried; set => _isMarried = value; }
    public Ring Ring { get => _ring; set => _ring = value; }
    public Newlywed(){}

    public Newlywed(string name)
    {
        _budget = (uint)new Random().Next(3000, 10000);
        _name = name;
    }

    public static void InviteGuests(string[] names, Wedding wedding)
    {
        try
        {
            for(int i = 0; i < names.Length; i++)
            {
                Guest guest = new Guest(names[i]);
                wedding.Guests.Add(guest);
            }
        }
        catch
        {
            throw new IndexOutOfRangeException("You have chosen the options out of bounds of array");
        }
       
    }
}