using Microsoft.EntityFrameworkCore;
using TrainScheduler.Model;

namespace TrainScheduler.Utilities;

public static class TrainFinder
{
    public static IQueryable<TrainModel> FindTrains(TrainModel train, IEnumerable<TrainModel> trains, DateTime departureTimeLowLimit,
        DateTime departureTimeUpperLimit, DateTime arrivalTimeLowLimit, DateTime arrivalTimeUpperLimit,
        string travelTime, bool numberCheck, bool departureStationCheck, bool arrivalStationCheck,
        bool departureTimeCheck, bool arrivalTimeCheck, bool travelTimeCheck)
    {

        var query = trains.AsQueryable();

        if (numberCheck)
            query = query.Where(t => t.Number == train.Number);
        if (!string.IsNullOrEmpty(train.DepartureStation) && departureStationCheck)
            query = query.Where(t => t.DepartureStation == train.DepartureStation);
        if (!string.IsNullOrEmpty(train.ArrivalStation) && arrivalStationCheck)
            query = query.Where(t => t.ArrivalStation == train.ArrivalStation);
        if (departureTimeCheck)
        {
            query = query.Where(t =>
                t.DepartureTime >= departureTimeLowLimit &&
                t.DepartureTime <= departureTimeUpperLimit);
        }

        if (arrivalTimeCheck)
        {
            query = query.Where(t =>
                t.ArrivalTime >= arrivalTimeLowLimit &&
                t.ArrivalTime <= arrivalTimeUpperLimit);
        }

        if (!string.IsNullOrEmpty(travelTime) && travelTimeCheck)
        {
            TimeSpan templateTimeSpan = Converter.ConvertStringToTimeSpan(travelTime);
            query = query.ToList().Where(t =>
                (int)t.TravelTime.TotalHours == (int)templateTimeSpan.TotalHours &&
                t.TravelTime.Minutes == templateTimeSpan.Minutes).AsQueryable();
        }

        return query;
    }
}