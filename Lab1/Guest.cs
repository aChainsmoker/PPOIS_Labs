namespace Lab1;

public class Guest
{
    private string _name;
    private uint _hungerLevel;
    
    public uint HungerLevel {get => _hungerLevel; set => _hungerLevel = value; }
    public string Name { get => _name; set => _name = value; }

    public Guest(string name)
    {
        _name = name;
        _hungerLevel = (uint) new Random().Next(1, 10);
    }
}