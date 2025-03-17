namespace Lab1;

public class Banquet
{
    public static readonly int AmountOfDishes = 5;
    
    private List<Guest> _guests;
    private List<Dish> _dishes;
    private bool _wasHeld;
    
    public List<Dish> Dishes { get => _dishes; set => _dishes = value; }
    public bool WasHeld { get => _wasHeld; set => _wasHeld = value; }
    public Banquet(){}
    public Banquet(List<Guest> guests)
    {
        _dishes = new List<Dish>();
    }
    
}