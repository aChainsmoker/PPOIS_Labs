using CommunityToolkit.Mvvm.ComponentModel;

namespace TrainScheduler.ViewModel;

public partial class SearchWithFiltersWindowViewModel : ObservableObject
{
    [ObservableProperty] private int _number;
    [ObservableProperty] private string _departureStation;
    [ObservableProperty] private string _arrivalStation;
    [ObservableProperty] private DateTime _departureTimeUpperLimit = DateTime.Now;
    [ObservableProperty] private DateTime _arrivalTimeUpperLimit = DateTime.Now;
    [ObservableProperty] private DateTime _departureTimeLowLimit = DateTime.Now;
    [ObservableProperty] private DateTime _arrivalTimeLowLimit = DateTime.Now;
    [ObservableProperty] private TimeSpan _departureTimeUpperLimitSpan;
    [ObservableProperty] private TimeSpan _arrivalTimeUpperLimitSpan;
    [ObservableProperty] private TimeSpan _departureTimeLowLimitSpan;
    [ObservableProperty] private TimeSpan _arrivalTimeLowLimitSpan;
    [ObservableProperty] private string _travelTime;
    [ObservableProperty] private bool _numberCheck;
    [ObservableProperty] private bool _departureStationCheck;
    [ObservableProperty] private bool _arrivalStationCheck;
    [ObservableProperty] private bool _departureTimeCheck;
    [ObservableProperty] private bool _arrivalTimeCheck;
    [ObservableProperty] private bool _travelTimeCheck;

    protected TrainListViewModel _trainListViewModel;

    partial void OnDepartureTimeUpperLimitChanged(DateTime value)
    {
        DepartureTimeUpperLimit = DepartureTimeUpperLimit.Date + DepartureTimeUpperLimitSpan;
    }

    partial void OnArrivalTimeUpperLimitChanged(DateTime value)
    {
        ArrivalTimeUpperLimit = ArrivalTimeUpperLimit.Date + ArrivalTimeUpperLimitSpan;
    }

    partial void OnDepartureTimeLowLimitChanged(DateTime value)
    {
        DepartureTimeLowLimit = DepartureTimeLowLimit.Date + DepartureTimeLowLimitSpan;
    }

    partial void OnArrivalTimeLowLimitChanged(DateTime value)
    {
        ArrivalTimeLowLimit = ArrivalTimeLowLimit.Date + ArrivalTimeLowLimitSpan;
    }

    partial void OnDepartureTimeUpperLimitSpanChanged(TimeSpan value)
    {
        DepartureTimeUpperLimit = DepartureTimeUpperLimit.Date + DepartureTimeUpperLimitSpan;
    }

    partial void OnArrivalTimeUpperLimitSpanChanged(TimeSpan value)
    {
        ArrivalTimeUpperLimit = ArrivalTimeUpperLimit.Date + ArrivalTimeUpperLimitSpan;
    }

    partial void OnDepartureTimeLowLimitSpanChanged(TimeSpan value)
    {
        DepartureTimeLowLimit = DepartureTimeLowLimit.Date + DepartureTimeLowLimitSpan;
    }

    partial void OnArrivalTimeLowLimitSpanChanged(TimeSpan value)
    {
        ArrivalTimeLowLimit = ArrivalTimeLowLimit.Date + ArrivalTimeLowLimitSpan;
    }

    protected void AssignDefaultValuesForTimeSpans()
    {
        DepartureTimeUpperLimitSpan = DepartureTimeUpperLimit.TimeOfDay;
        ArrivalTimeLowLimitSpan = ArrivalTimeLowLimit.TimeOfDay;
        DepartureTimeLowLimitSpan = DepartureTimeLowLimit.TimeOfDay;
        ArrivalTimeUpperLimitSpan = ArrivalTimeUpperLimit.TimeOfDay;
    }
}