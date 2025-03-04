namespace Lab1;

public class Banquet
{
    public static readonly int AmountOfDishes = 5;
    
    private List<Guest> _guests;
    private List<Dish> _dishes;
    
    public List<Dish> Dishes { get => _dishes; set => _dishes = value; }

    public Banquet(List<Guest> guests)
    {
        _dishes = new List<Dish>();
    }
    
}