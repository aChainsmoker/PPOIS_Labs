namespace Lab1;

public class Ceremony
{
    private List<Guest> _guests;
    private Groom _groom;
    private Fiancee _fiancee;
    
    public List<Guest> Guests { get => _guests; set => _guests = value; }

    public Ceremony(){}
    public Ceremony(Groom groom, Fiancee fiancee, List<Guest> guests)
    {
        _guests = new List<Guest>();
        _groom = groom;
        _fiancee = fiancee;
    }

    public void DeclareHusbandAndWife(Groom groom, Fiancee fiancee)
    {
        groom.IsMarried = true;
        fiancee.IsMarried = true;
    }
}