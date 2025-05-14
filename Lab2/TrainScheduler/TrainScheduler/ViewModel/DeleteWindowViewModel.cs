using CommunityToolkit.Mvvm.Input;
using TrainScheduler.Model;
using TrainScheduler.Utilities;
using Microsoft.EntityFrameworkCore;

namespace TrainScheduler.ViewModel;

public partial class DeleteWindowViewModel : SearchWithFiltersWindowViewModel
{
    private DeleteWindow _deleteWindow;

    public DeleteWindowViewModel(TrainListViewModel trainListViewModel)
    {
        _trainListViewModel = trainListViewModel;
        AssignDefaultValuesForTimeSpans();

        _deleteWindow = new DeleteWindow(this);
        Application.Current?.OpenWindow(_deleteWindow);
    }

    [RelayCommand]
    private void DeleteTrains()
    {
        TrainModel trainsToFind = new TrainModel()
        {
            Number = Number,
            DepartureStation = DepartureStation,
            ArrivalStation = ArrivalStation,
        };

        List<TrainModel> trainListToDelete = new List<TrainModel>();

        try
        {
            trainListToDelete = TrainFinder.FindTrains(trainsToFind, _trainListViewModel.Trains,
                DepartureTimeLowLimit, DepartureTimeUpperLimit, ArrivalTimeLowLimit, ArrivalTimeUpperLimit, TravelTime,
                NumberCheck, DepartureStationCheck, ArrivalStationCheck, DepartureTimeCheck, ArrivalTimeCheck,
                TravelTimeCheck).ToList();
        }
        catch (ArgumentException ex)
        {
            _deleteWindow.Page?.DisplayAlert("Error!",
                "Travel Time is in incorrect format. Input must be {Hours:Minutes}.", "Close");
            ;
            return;
        }
        catch (StackOverflowException ex)
        {
            _deleteWindow.Page?.DisplayAlert("Error!",
                "Entered Travel Time is too big for any of the passengers to get off the train alive.", "Close");
            ;
            return;
        }

        (_trainListViewModel.Trains as DbSet<TrainModel>).ToList().RemoveAll(train => trainListToDelete.Contains(train));

        if (trainListToDelete.Count > 0)
        {
            _trainListViewModel.UpdateTrainList();
            DeleteFromDatabase(trainListToDelete);
        }
        _trainListViewModel.UpdateTrainList();
        DisplayDeletionResult(trainListToDelete.Count);
    }

    private void DisplayDeletionResult(int amountOfDeletedItems)
    {
        string message;

        if (amountOfDeletedItems == 0)
            message = "Couldn't find trains with entered parameters...";
        else
            message = $"{amountOfDeletedItems} trains was deleted.";

        _deleteWindow.Page?.DisplayAlert("Deletion Result", message, "Close");
    }

    private void DeleteFromDatabase(List<TrainModel> trainListToDelete)
    {
        _trainListViewModel.DeleteFromDb(trainListToDelete);
        _trainListViewModel.SaveDbChanges();
    }
}