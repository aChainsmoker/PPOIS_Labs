using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrainScheduler.Model;
using Microsoft.EntityFrameworkCore;

namespace TrainScheduler.ViewModel;

public partial class AddWindowViewModel : ObservableObject
{
    private TrainListViewModel _trainListViewModel;
    [ObservableProperty] private int _number;
    [ObservableProperty] private string _departureStation;
    [ObservableProperty] private string _arrivalStation;
    [ObservableProperty] private DateTime _departureTime = DateTime.Now;
    [ObservableProperty] private DateTime _arrivalTime = DateTime.Now;
    [ObservableProperty] private TimeSpan _departureTimeSpan;
    [ObservableProperty] private TimeSpan _arrivalTimeSpan;

    private AddWindow _addWindow;


    partial void OnDepartureTimeChanged(DateTime value)
    {
        DepartureTime = DepartureTime.Date + DepartureTimeSpan;
    }

    partial void OnArrivalTimeChanged(DateTime value)
    {
        ArrivalTime = ArrivalTime.Date + ArrivalTimeSpan;
    }

    partial void OnDepartureTimeSpanChanged(TimeSpan value)
    {
        DepartureTime = DepartureTime.Date + DepartureTimeSpan;
    }

    partial void OnArrivalTimeSpanChanged(TimeSpan value)
    {
        ArrivalTime = ArrivalTime.Date + ArrivalTimeSpan;
    }

    public AddWindowViewModel(TrainListViewModel trainListViewModel)
    {
        _departureTimeSpan = _departureTime.TimeOfDay;
        _arrivalTimeSpan = _arrivalTime.TimeOfDay;
        _trainListViewModel = trainListViewModel;
        _addWindow = new AddWindow(this);
        Application.Current?.OpenWindow(_addWindow);
    }

    [RelayCommand]
    private void AddTrain()
    {
        if (string.IsNullOrEmpty(DepartureStation) || string.IsNullOrEmpty(ArrivalStation))
        {
            _addWindow?.Page?.DisplayAlert("Error!", "All entries must be filled.", "Close");
            return;
        }

        if (DepartureTime > ArrivalTime)
        {
            _addWindow?.Page?.DisplayAlert("Error!", "Arrival Time cannot be before Departure Time.", "Close");
            return;
        }

        TrainModel trainToAdd = new TrainModel()
        {
            Number = Number, ArrivalTime = ArrivalTime, DepartureTime = DepartureTime,
            DepartureStation = DepartureStation, ArrivalStation = ArrivalStation
        };
        AddToDatabase(trainToAdd);
        Application.Current?.CloseWindow(_addWindow);
        _trainListViewModel.UpdateTrainList();
    }

    private void AddToDatabase(TrainModel trainToAdd)
    {
        (_trainListViewModel.Trains as DbSet<TrainModel>).Add(trainToAdd);
        _trainListViewModel.SaveDbChanges();
    }
}