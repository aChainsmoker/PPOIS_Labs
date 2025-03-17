namespace Lab1;

public class WeddingMap
{
    private List<WeddingPlace> _weddingPlaces;
    private string[] _locations;
    
    public List<WeddingPlace> WeddingPlaces { get => _weddingPlaces; set => _weddingPlaces = value; }

    public WeddingMap()
    {
        _weddingPlaces = new List<WeddingPlace>();
        _locations = new string[]
        {
            "Restaurant in San-Francisco", "Church in Minsk", "Castle in London", "Theatre in Sydney", "Restaurant in Moscow", "Palace of the Republic in Minsk", "Coast on Bali"
        };
            
        
        
        for (int i = 0; i < _locations.Length; i++)
        {
            int days = new Random().Next(5, 90);
            int hours = new Random().Next(-24, 24);
            DateTime todayDate = DateTime.Now.AddDays(days).AddHours(hours).AddMinutes(60 - DateTime.Now.Minute);
            uint price = (uint)new Random().Next(1000, 10000);
            uint guestCapacity = price/1000;
            
            WeddingPlace weddingPlace = new WeddingPlace(price, todayDate, guestCapacity, _locations[i]);
            _weddingPlaces.Add(weddingPlace);
        }
    }
    public void AssignThePlace(Wedding wedding, int indexOfPlace)
    {
        wedding.WeddingPlace = _weddingPlaces[indexOfPlace];
        wedding.SharedBudget -= (int)_weddingPlaces[indexOfPlace].Price;
    }

    public void ReturnMoney(Wedding wedding)
    {
        wedding.SharedBudget += (int)wedding.WeddingPlace.Price;
    }
}