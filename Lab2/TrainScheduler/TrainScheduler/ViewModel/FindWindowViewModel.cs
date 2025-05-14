using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrainScheduler.Model;
using TrainScheduler.Utilities;

namespace TrainScheduler.ViewModel;

public partial class FindWindowViewModel : SearchWithFiltersWindowViewModel
{
    [ObservableProperty] private TrainListViewModel _searchResultTrainListViewModel;

    private FindWindow _findWindow;

    public FindWindowViewModel(TrainListViewModel trainListViewModel)
    {
        _trainListViewModel = trainListViewModel;

        _searchResultTrainListViewModel = new TrainListViewModel(_trainListViewModel.Trains);
        _searchResultTrainListViewModel.UpdateTrainList();
        AssignDefaultValuesForTimeSpans();

        _findWindow = new FindWindow(this);
        Application.Current?.OpenWindow(_findWindow);
    }

    [RelayCommand]
    private void FindTrains()
    {
        var trainModelToFind = new TrainModel()
        {
            Number = Number,
            DepartureStation = DepartureStation,
            ArrivalStation = ArrivalStation
        };
        try
        {
            SearchResultTrainListViewModel.Trains = TrainFinder.FindTrains(trainModelToFind,
                    _trainListViewModel.Trains, DepartureTimeLowLimit, DepartureTimeUpperLimit,
                    ArrivalTimeLowLimit, ArrivalTimeUpperLimit, TravelTime, NumberCheck, DepartureStationCheck,
                    ArrivalStationCheck, DepartureTimeCheck, ArrivalTimeCheck, TravelTimeCheck).ToList();
        }
        catch (ArgumentException ex)
        {
            _findWindow.Page?.DisplayAlert("Error!",
                "Travel Time is in incorrect format. Input must be {Hours:Minutes}.", "Close");
            return;
        }
        catch (StackOverflowException ex)
        {
            _findWindow.Page?.DisplayAlert("Error!",
                "Entered Travel Time is too big for any of the passengers to get off the train alive.", "Close");
            return;
        }

        SearchResultTrainListViewModel.PageNumber = 1;

        SearchResultTrainListViewModel.UpdateTrainList();
    }
}