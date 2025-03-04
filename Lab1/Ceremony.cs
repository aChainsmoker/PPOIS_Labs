namespace Lab1;

public class Ceremony
{
    private List<Guest> _guests;
    private Husband _husband;
    private Wife _wife;
    
    public List<Guest> Guests { get => _guests; set => _guests = value; }

    public Ceremony(Husband husband, Wife wife, List<Guest> guests)
    {
        _guests = new List<Guest>();
        _husband = husband;
        _wife = wife;
    }

    public void DeclareHusbandAndWife(Husband husband, Wife wife)
    {
        husband.IsMarried = true;
        wife.IsMarried = true;
    }
}