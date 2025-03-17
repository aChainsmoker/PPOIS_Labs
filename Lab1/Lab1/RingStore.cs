namespace Lab1;

public class RingStore
{
    private string[] _brands;
    private List<Ring> _rings;
    
    public List<Ring> Rings {get => _rings; set => _rings = value; }

    public RingStore()
    {
        _rings = new List<Ring>();
        
        _brands = new string[]
            { "Tiffany & Co", "Cartier", "Harry Winston", "Bulgari", "Van Cleef & Arpels", "Graff"};
        
        for (int i = 0; i < _brands.Length; i++)
        {
            _rings.Add(new Ring((uint)(new Random().Next(1, 10000)), _brands[i]));
        }
    }

    public void AssignTheRings(Wedding wedding, int ringIndex)
    {
        wedding.Groom.Ring = _rings[ringIndex];
        wedding.Fiancee.Ring = _rings[ringIndex];
        wedding.SharedBudget -= (int)_rings[ringIndex].Price;
    }

    public void ReturnMoney(Wedding wedding)
    {
        wedding.SharedBudget += (int)wedding.Groom.Ring.Price;
    }
}