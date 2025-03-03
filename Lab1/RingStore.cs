namespace Lab1;

public class RingStore
{
    private string[] _brands;
    private List<Ring> _rings;

    public RingStore()
    {
        _brands = new string[]
            { "Tiffany & Co", "Cartier", "Harry Winston", "Bulgari", "Van Cleef & Arpels", "Graff"};
        
        for (int i = 0; i < _brands.Length; i++)
        {
            _rings.Add(new Ring((uint)(new Random().Next(1, 10000)), _brands[i]));
        }
    }
}