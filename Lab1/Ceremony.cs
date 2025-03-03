namespace Lab1;

public class Ceremony
{
    private List<Guest> _guests;
    private Husband _husband;
    private Wife _wife;
    private Ring _ring;

    public Ceremony(Husband husband, Wife wife, Ring ring)
    {
        _guests = new List<Guest>();
        _husband = husband;
        _wife = wife;
        _ring = ring;
    }
}