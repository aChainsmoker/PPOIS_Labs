using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace TrainScheduler.Model;

public class TrainModel
{
    private uint _id;
    private int _number;
    private string _departureStation;
    private string _arrivalStation;
    private DateTime _departureTime = DateTime.Now;
    private DateTime _arrivalTime = DateTime.Now;
    

    public uint Id { get => _id; set => _id = value; }
    public int  Number { get => _number; set => _number = value; }
    public string DepartureStation { get => _departureStation; set => _departureStation = value; }
    public string ArrivalStation { get => _arrivalStation; set => _arrivalStation = value; }
    public DateTime DepartureTime { get => _departureTime; set => _departureTime = value; }
    public DateTime ArrivalTime { get => _arrivalTime; set => _arrivalTime = value; }
    public TimeSpan TravelTime { get => ArrivalTime - DepartureTime;  }
    public string FormattedTravelTime =>
    $"{(int)TravelTime.TotalHours}:{TravelTime.Minutes:D2}";
}
