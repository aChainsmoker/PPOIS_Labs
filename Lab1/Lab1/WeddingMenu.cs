namespace Lab1;

public class WeddingMenu
{
    private List<KeyValuePair<string, uint>>_menu;
    private List<Dish> _dishes;
    
    public List<Dish> Dishes { get => _dishes; set => _dishes = value; }

    public WeddingMenu()
    {
        _menu = new List<KeyValuePair<string, uint>>()
        {
            new("Caesar Salad", 3),
            new("Bruschetta", 2),
            new("Shrimp Cocktail", 4),
            new("Beef Wellington", 9),
            new("Grilled Salmon", 7),
            new("Chicken Alfredo", 8),
            new("Mashed Potatoes", 6),
            new("Roasted Vegetables", 5),
            new("Truffle Mac and Cheese", 8),
            new("Wedding Cake", 4),
            new("Chocolate Fondue", 3),
            new("Fruit Tart", 2)
        };
        _dishes = new List<Dish>();
        
        for (int i = 0; i < _menu.Count; i++)
        {
            _dishes.Add(new Dish(_menu[i].Key, (uint)new Random().Next(10, 100), _menu[i].Value));
        }
    }

    public void AssignTheDishes(Wedding wedding, int[] indexesOfDishes)
    {
        for (int i = 0; i < Banquet.AmountOfDishes; i++)
        {
            wedding.Banquet.Dishes.Add(_dishes[indexesOfDishes[i]]);
            wedding.SharedBudget -= (int)_dishes[indexesOfDishes[i]].Price;
        }
    }
    
    public void ReturnMoney(Wedding wedding)
    {
        for (int i = 0; i < wedding.Banquet.Dishes.Count; i++)
        {
            wedding.SharedBudget += (int)wedding.Banquet.Dishes[i].Price;
        }
    }

}