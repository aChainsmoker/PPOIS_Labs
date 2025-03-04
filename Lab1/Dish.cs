namespace Lab1;

public class Dish
{
    private string _name;
    private uint _price;
    private uint _foodPower;

    public string Name { get => _name; set => _name = value; }
    public uint Price { get => _price; set => _price = value; }
    public uint FoodPower { get => _foodPower; set => _foodPower = value; }
    
    public Dish(string name, uint price, uint foodPower)
    {
        _name = name;
        _price = price;
        _foodPower = foodPower;
        
    }
}