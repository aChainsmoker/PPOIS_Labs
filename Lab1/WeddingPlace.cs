namespace Lab1;

public class WeddingPlace(uint price, DateTime date, uint guestCapacity, string location)
{
    private DateTime _date = date;
    private uint _price = price;
    private uint _guestCapacity = guestCapacity;
    private string _location = location;
    
    public DateTime Date { get => _date; set => _date = value; }
    public uint Price { get => _price; set => _price = value; }
    public uint GuestCapacity { get => _guestCapacity; set => _guestCapacity = value; }
    public string Location { get => _location; set => _location = value; }
}