using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using TrainScheduler.Model;

namespace TrainScheduler.ViewModel;

public partial class TrainListViewModel : ObservableObject
{
    private TrainListModel _model;

    [ObservableProperty] private int _pageNumber = 1;
    [ObservableProperty] private int _amountOfPages;
    [ObservableProperty] private int _amountOfItemsOnPage = 10;
    [ObservableProperty] private int[] _setOfNumbersOfAmountOfItemsOnPage = new int[] { 5, 10, 25, 50 };
    [ObservableProperty] private int _AmountOfItems;
    [ObservableProperty] private string _displayMode = "List";
    [ObservableProperty] private string[] _displayModes = ["List", "Tree"];
    [ObservableProperty] private List<TrainModel> _visibleTrains;

    private IEnumerable<TrainModel> _trainSource;

    public IEnumerable<TrainModel> Trains
    {
        get { return _trainSource; }
        set { _trainSource = value; }
    }


    public bool IsListVisible => DisplayMode == "List";
    public bool IsTreeVisible => DisplayMode == "Tree";

    partial void OnAmountOfItemsOnPageChanged(int value)
    {
        UpdateTrainList();
    }

    partial void OnDisplayModeChanged(string value)
    {
        OnPropertyChanged(nameof(IsListVisible));
        OnPropertyChanged(nameof(IsTreeVisible));
        UpdateTrainList();
    }

    public TrainListViewModel(TrainListModel model)
    {
        _model = model;
        _trainSource = model.Trains;
        UpdateTrainList();
    }

    public TrainListViewModel(IEnumerable<TrainModel> trains)
    {
        _trainSource = trains;
        UpdateTrainList();
    }

    public void UpdateTrainList()
    {
        if (!IsListVisible)
        {
            if (Trains is DbSet<TrainModel> trains)
                VisibleTrains = trains.ToList();
            return;
        }

        AmountOfItems = Trains.Count();
        AmountOfPages = Trains.Count() % _amountOfItemsOnPage == 0
            ? Trains.Count() / _amountOfItemsOnPage
            : Trains.Count() / _amountOfItemsOnPage + 1;


        int amountOfTrainsToShow = Trains.Count() - (PageNumber - 1) * _amountOfItemsOnPage < 10
            ? Trains.Count() - (PageNumber - 1) * _amountOfItemsOnPage
            : _amountOfItemsOnPage;
        if (AmountOfItemsOnPage > Trains.Count())
        {
            PageNumber = AmountOfPages;
            amountOfTrainsToShow = Trains.Count();
        }

        if (amountOfTrainsToShow <= 0)
        {
            PageNumber = AmountOfPages;
            amountOfTrainsToShow = Trains.Count() - (PageNumber - 1) * _amountOfItemsOnPage < 10
                ? Trains.Count() - (PageNumber - 1) * _amountOfItemsOnPage
                : _amountOfItemsOnPage;
        }

        if (Trains.Count() == 0)
        {
            PageNumber = 1;
            amountOfTrainsToShow = 0;
        }

        int skip = (PageNumber - 1) * _amountOfItemsOnPage;
        VisibleTrains = Trains.Skip(skip).Take(_amountOfItemsOnPage).ToList();
    }


    [RelayCommand]
    private void GoForward()
    {
        if (PageNumber >= AmountOfPages)
            return;
        PageNumber++;
        UpdateTrainList();
    }

    [RelayCommand]
    private void GoBack()
    {
        if (PageNumber <= 1)
            return;
        PageNumber--;
        UpdateTrainList();
    }

    [RelayCommand]
    private void GoFirst()
    {
        if (PageNumber == 1)
            return;
        PageNumber = 1;
        UpdateTrainList();
    }

    [RelayCommand]
    private void GoLast()
    {
        if (PageNumber == AmountOfPages)
            return;
        PageNumber = AmountOfPages;
        UpdateTrainList();
    }

    public void ClearTracking()
    {
        _model.DbContext.ChangeTracker.Clear();
        _model.Trains.ExecuteDelete();
    }

    public void SaveDbChanges()
    {
        _model.DbContext.SaveChanges();
    }

    public void DeleteFromDb(List<TrainModel> trainsToDelete)
    {
        _model.Trains.RemoveRange(trainsToDelete);
    }
}